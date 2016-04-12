If (-not (Test-Path Env:\BUILD_BUILDNUMBER))
{
    Write-Host 'BUILD_BUILDNUMBER environment variable is not defined.';

    Return;
}

$buildVersion = [System.Uri](Get-Content Env:\BUILD_BUILDNUMBER)
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

$currentDir = (Get-Location).Path
UpdateAssemblyInfoWithBuildNumber (Join-Path $currentDir "SolutionAssemblyInfo.cs") $buildVersion
UpdateNuSpecWithBuildNumber (Join-Path $currentDir "Compute.Client\Compute.Client.nuspec") $buildVersion

