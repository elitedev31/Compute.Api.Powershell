Param(
    [Parameter(Mandatory=$True)]
    [ValidateNotNullOrEmpty()]
    [string] $ProductVersion,

	[ValidateNotNullOrEmpty()]
	[Parameter(Mandatory = $true)]
	[String] $ReleaseTag
)

Function Get-BuildVersion()
{
    Param(
        # ProductVersion is Major.Minor eg 1.2
        [Parameter(Mandatory=$True)]
        [ValidateNotNullOrEmpty()]
        [string] $ProductVersion
    )
    
    # Expecting BUILD_BUILDURI be something like vstfs:///Build/Build/35
    If (-not (Test-Path Env:\BUILD_BUILDURI))
    {
        throw 'BUILD_BUILDURI environment variable is not defined.';    
    }
    
    $parsedVersion = [Version]::Parse($ProductVersion)
    
    $buildUri = [System.Uri](Get-Content Env:\BUILD_BUILDURI)

    Write-Host "BuildUri : $buildUri";
    $buildId = Split-Path -Leaf $buildUri.LocalPath
    Write-Host "buildId : $($buildUri.LocalPath)";
    return @{ AssemblyVersion = "$($parsedVersion.Major).$($parsedVersion.Minor).$($buildId).0" ; PackageVersion = "$($parsedVersion.Major).$($parsedVersion.Minor).$($buildId)"}
}
import-module .\UpdateAssemblyInfo.psm1
$buildVersion = Get-BuildVersion -ProductVersion $ProductVersion
Write-Host "Updating solution versions to $($buildVersion.AssemblyVersion) and package version  $($buildVersion.PackageVersion)";

$currentDir = (Get-Location).Path
Update-AssemblyInfoWithBuildNumber -SolutionAssemblyInfoFile (Join-Path $currentDir "SolutionAssemblyInfo.cs") -Version $buildVersion
Update-NuSpecWithBuildNumber -NuSpecFile (Join-Path $currentDir "Compute.Client\Compute.Client.nuspec") -Version "$($buildVersion.PackageVersion)-$ReleaseTag"

