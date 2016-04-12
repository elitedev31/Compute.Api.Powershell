Param(
    [Parameter(Mandatory=$True)]
    [ValidateNotNullOrEmpty()]
    [string] $ProductVersion,

	[ValidateNotNullOrEmpty()]
	[Parameter(Mandatory = $true)]
	[String] $ReleaseTag
)


Function UpdateAssemblyInfoWithBuildNumber
{
Param(       
        [Parameter(Mandatory=$True)]
        [ValidateNotNullOrEmpty()]
        [string] $SolutionAssemblyInfoFile,
        
        [Parameter(Mandatory=$True)]
        [ValidateNotNullOrEmpty()]
        [string] $Version
    ) 

    Write-Host "Updating solution versions to $Version";
    $solutionAssemblyInfo = Get-Content $SolutionAssemblyInfoFile
    $updatedVersionInfo = $SolutionAssemblyInfoFile -replace "Version\(`"(\d+)\.(\d+)\.(\d+)\.\d+`"\)\]`$", "Version(`"$Version`")]"

    $updatedVersionInfo | Out-File $SolutionAssemblyInfoFile
}

Function UpdateNuSpecWithBuildNumber
{
 Param(       
        [Parameter(Mandatory=$True)]
        [ValidateNotNullOrEmpty()]
        [string] $NuSpecFile,
        
        [Parameter(Mandatory=$True)]
        [ValidateNotNullOrEmpty()]
        [string] $Version
    ) 

    Write-Host "Updating nuget versions for $NuSpecFile to $Version";
    $nuSpec = Get-Content $NuSpecFile
    $nuSpec = $nuSpec -replace "\<version\>(\d+)\.(\d+)\.(\d+).(\d+)\<\/version\>", "<version>$Version</version>"
    $nuSpec = $nuSpec -replace "[\$]version\$", "$Version"

    Set-Content $NuSpecFile -Value $nuSpec
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

$buildVersion = Get-BuildVersion -ProductVersion $ProductVersion
Write-Host "Updating solution versions to $buildVersion";

$currentDir = (Get-Location).Path
UpdateAssemblyInfoWithBuildNumber -SolutionAssemblyInfoFile (Join-Path $currentDir "SolutionAssemblyInfo.cs") $buildVersion
UpdateNuSpecWithBuildNumber -NuSpecFile (Join-Path $currentDir "Compute.Client\Compute.Client.nuspec") "$buildVersion-$ReleaseTag"

