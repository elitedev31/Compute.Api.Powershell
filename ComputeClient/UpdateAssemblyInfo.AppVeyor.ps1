Function Get-BuildVersion()
{     
     $postFix = $env:BUILD_VERSION_POSTFIX
     $majorMinorVersion = $env:BUILD_VERSION
     $branchName = $env:APPVEYOR_REPO_BRANCH
     $buildNumber = $env:APPVEYOR_BUILD_NUMBER
     # Assumes if there is an environment variable set, then use it to override the build version and the version tag
     $branchName = ($branchName -replace "/", "").ToUpper()

     if (-Not [string]::IsNullOrEmpty($branchName)) {

         $branchMajorMinorVersionVariableName = "$($branchName)_BUILD_VERSION"
         $branchPostFixVariableName = "$($branchName)_VERSION_POSTFIX"
         Write-Host "Branch specific environment variable are $branchMajorMinorVersionVariableName and $branchPostFixVariableName";
         $branchMajorMinorVersion = [Environment]::GetEnvironmentVariable($branchMajorMinorVersionVariableName)
         $branchPostFix = [Environment]::GetEnvironmentVariable($branchPostFixVariableName)
         if($branchMajorMinorVersion -ne $null) {
            $majorMinorVersion = $branchMajorMinorVersion
         }
             
         if($branchPostFix -ne $null) {
            $postFix = $branchPostFix
         }             
     }      

    Update-AppveyorBuild -Version "$($majorMinorVersion).$($buildNumber)"
    return @{ BuildVersion = "$($majorMinorVersion).$($buildNumber)" ; PostFix = $postFix ; };
}

$currentDir = $PSScriptRoot
import-module (Join-Path $currentDir "UpdateAssemblyInfo.psm1")

$buildVersion = Get-BuildVersion
Write-Host "Updating solution versions to $($buildVersion.BuildVersion).0 , releaseTag : $($buildVersion.PostFix)";

Update-AssemblyInfoWithBuildNumber -SolutionAssemblyInfoFile (Join-Path $currentDir "SolutionAssemblyInfo.cs") -Version "$($buildVersion.BuildVersion).0"

$nugetVersion = "$($buildVersion.BuildVersion)"
if(-Not [string]::IsNullOrEmpty($buildVersion.PostFix))
{
    $nugetVersion = "$($buildVersion.BuildVersion)-$($buildVersion.PostFix)"
}

Write-Host "Updating Nuget package versions to $nugetVersion";
Update-NuSpecWithBuildNumber -NuSpecFile (Join-Path $currentDir "Compute.Client\Compute.Client.nuspec") -Version $nugetVersion

