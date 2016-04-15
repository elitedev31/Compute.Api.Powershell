Function Get-BuildPostFix()
{   
     $postfix = $env:COMPUTEAPI_BUILD_POSTFIX

     if ($env:APPVEYOR_REPO_BRANCH -eq "master") {
         $postfix = ""
     }
     elseif ($env:APPVEYOR_REPO_BRANCH -ne "develop") {
         $postfix = "-develop"
     }else {
         $postfix = "-feature"
     }

    return "$postfix"
}

import-module .\UpdateAssemblyInfo.psm1
$buildVersion = $env:APPVEYOR_BUILD_VERSION
$releaseTag = Get-BuildPostFix
Write-Host "Updating solution versions to $buildVersion , releaseTag : $releaseTag";

$currentDir = (Get-Location).Path
Update-AssemblyInfoWithBuildNumber -SolutionAssemblyInfoFile (Join-Path $currentDir "SolutionAssemblyInfo.cs") -Version $buildVersion
Update-NuSpecWithBuildNumber -NuSpecFile (Join-Path $currentDir "Compute.Client\Compute.Client.nuspec") -Version "$buildVersion-$releaseTag"

