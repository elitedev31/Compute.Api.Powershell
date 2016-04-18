Function Get-BuildPostFix()
{   
     $postfix = $env:COMPUTEAPI_BUILD_POSTFIX

     if ($env:APPVEYOR_REPO_BRANCH -eq "master") {
         $postfix = $null
     }
     elseif ($env:APPVEYOR_REPO_BRANCH -ne "develop") {
         $postfix = "develop"
     }else {
         $postfix = "feature"
     }

    return "$postfix"
}
$currentDir = $PSScriptRoot
import-module (Join-Path $currentDir "UpdateAssemblyInfo.psm1")
$buildVersion = $env:APPVEYOR_BUILD_VERSION
$releaseTag = Get-BuildPostFix
Write-Host "Updating solution versions to $buildVersion , releaseTag : $releaseTag";

Update-AssemblyInfoWithBuildNumber -SolutionAssemblyInfoFile (Join-Path $currentDir "SolutionAssemblyInfo.cs") -Version $buildVersion

$nugetVersion = "$buildVersion"
if($postfix -ne $null)
{
    $nugetVersion = "$buildVersion-$releaseTag"
}

Update-NuSpecWithBuildNumber -NuSpecFile (Join-Path $currentDir "Compute.Client\Compute.Client.nuspec") -Version "$nugetVersion"

