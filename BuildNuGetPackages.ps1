Param([switch] $Publish, [switch] $PackageVersionsAreRelease)

# If the $PackagesAreRelease flag is not set, built packages are marked as pre-release.
 If ($PackageVersionsAreRelease)
 {
	Write-Host 'Building RELEASE package versions'
 }

# Prevent stupid NuGet warning.
Set-Item -Path 'Env:\EnableNuGetPackageRestore' -Value 'true'

If (Test-Path Env:\TF_BUILD_BUILDURI)
{
    $buildUri = [System.Uri](Get-Content Env:\TF_BUILD_BUILDURI)
    $buildId = Split-Path -Leaf $buildUri.LocalPath

    Write-Host "TFS build Id is $buildId."
}
Else
{
    Write-Host 'Warning - TF_BUILD_BUILDURI environment variable is not defined. Build number defaults to 0.'
    
    $buildId = 0
}

$nuGetPackagesFolder = '.\NuGetPackages'
If (-not (Test-Path $nuGetPackagesFolder))
{
    mkdir $nuGetPackagesFolder
}
cd $nuGetPackagesFolder

Function BuildProject([string]$projectFile, [string]$configuration = 'Release')
{
    If ([string]::IsNullOrWhiteSpace($projectFile))
    {
        Throw "Invalid project file (cannot be null, empty, or entirely composed of whitespace)."
    }

    Write-Host '================================================================================'
	Write-Host "Building database project '$projectFile'..."
    C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe "$projectFile" /t:Build /p:Configuration=$configuration /v:minimal
}

Function BuildPackageFromNuSpec([string]$nuSpecFile)
{
    If ([string]::IsNullOrWhiteSpace($nuSpecFile))
    {
        Throw "Invalid NuSpec file (cannot be null, empty, or entirely composed of whitespace)."
    }
    
    $packageVersion = "1.0.$buildId"
    If (-not $PackageVersionsAreRelease)
    {
        $packageVersion += '-pre'
    }

	Write-Host '================================================================================'
	Write-Host "Building version '$packageVersion' of '$nuSpecFile'..."
    ..\Common\BuildSupport\NuGet\NuGet.exe pack "$nuSpecFile" -NonInteractive -Version "$packageVersion" -Verbosity Detailed -NoPackageAnalysis
}

Function BuildPackageFromProject([string]$packageProjectFile)
{
    If ([string]::IsNullOrWhiteSpace($packageProjectFile))
    {
        Throw "Invalid package project file (cannot be null, empty, or entirely composed of whitespace)."
    }
    
    $packageVersion = "1.0.$buildId"
    If (-not $PackageVersionsAreRelease)
    {
        $packageVersion += '-pre'
    }

	Write-Host '================================================================================'
	Write-Host "Building version '$packageVersion' of '$packageProjectFile'..."
    ..\Common\BuildSupport\NuGet\NuGet.exe pack "$packageProjectFile" -Build -Prop Configuration=Release -Prop Platform=AnyCPU -NonInteractive -Version "$packageVersion" -Verbosity Detailed -NoPackageAnalysis
}

BuildPackageFromNuSpec('..\ComputeClient\Compute.Contracts\Compute.Contracts.nuspec')
BuildPackageFromNuSpec('..\ComputeClient\Compute.Client\Compute.Client.nuspec')

cd ..

If ($Publish)
{
    Get-ChildItem -Path $nuGetPackagesFolder -Filter '*.nupkg' | Copy-Item -Destination '\\aperture-scc\NuGetPackages'
}
