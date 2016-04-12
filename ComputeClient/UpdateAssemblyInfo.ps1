Param(
    [Parameter(Mandatory=$True)]
    [ValidateNotNullOrEmpty()]
    [string] $ProductVersion,

	[ValidateNotNullOrEmpty()]
	[Parameter(Mandatory = $true)]
	[String] $ReleaseTag
)

$buildVersion = Get-BuildVersion $ProductVersion
Write-Host "Updating solution versions to $buildVersion";

Function UpdateAssemblyInfoWithBuildNumber([string] $solutionAssemblyInfoFile, [string] $version)
{
    Write-Host "Updating solution versions to $version";
    $solutionAssemblyInfo = Get-Content $solutionAssemblyInfoFile
    $updatedVersionInfo = $solutionAssemblyInfo -replace "Version\(`"(\d+)\.(\d+)\.(\d+)\.\d+`"\)\]`$", "Version(`"$version`")]"

    $updatedVersionInfo | Out-File $solutionAssemblyInfoFile
}

Function UpdateNuSpecWithBuildNumber([string] $nuSpecFile, [string] $version)
{
    Write-Host "Updating nuget versions for $nuSpecFile to $version";
    $nuSpec = Get-Content $nuSpecFile
    $nuSpec = $nuSpec -replace "\<version\>(\d+)\.(\d+)\.(\d+).(\d+)\<\/version\>", "<version>$version</version>"
    $nuSpec = $nuSpec -replace "[\$]version\$", "$version"

    Set-Content $nuSpecFile -Value $nuSpec
}

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
    $buildId = Split-Path -Leaf $buildUri.LocalPath
    
    $buildVersionProperties = @{};
    $buildVersionProperties["Major"] = $parsedVersion.Major
    $buildVersionProperties["Minor"] = $parsedVersion.Minor
    $buildVersionProperties["Build"] = $buildId
    
    $buildVersion = New-Object PSObject -Property $buildVersionProperties
    return $buildVersion
}

$currentDir = (Get-Location).Path
UpdateAssemblyInfoWithBuildNumber (Join-Path $currentDir "SolutionAssemblyInfo.cs") $buildVersion
UpdateNuSpecWithBuildNumber (Join-Path $currentDir "Compute.Client\Compute.Client.nuspec") "$buildVersion-$ReleaseTag"

