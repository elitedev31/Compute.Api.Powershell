Param(
	[ValidateNotNullOrEmpty()]
	[Parameter(Mandatory = $true)]
	[String] $ReleaseVersion
)

Write-Host "Updating solution versions to $ReleaseVersion";

Function UpdateAssemblyInfoWithBuildNumber([string] $solutionAssemblyInfoFile, [string] $version)
{
    $solutionAssemblyInfo = Get-Content $solutionAssemblyInfoFile
    $updatedVersionInfo = $solutionAssemblyInfo -replace "Version\(`"(\d+)\.(\d+)\.(\d+)\.\d+`"\)\]`$", "Version(`"$version`")]"

    $updatedVersionInfo | Out-File $solutionAssemblyInfoFile
}

Function UpdateNuSpecWithBuildNumber([string] $nuSpecFile, [string] $version)
{
    Write-Host "Updating nuget versions for $nuSpecFile to $majorVersion.$minorVersion.$buildId.0";
    $nuSpec = Get-Content $nuSpecFile
    $nuSpec = $nuSpec -replace "\<version\>(\d+)\.(\d+)\.(\d+).(\d+)\<\/version\>", "<version>$version</version>"
    $nuSpec = $nuSpec -replace "[\$]version\$", "$version"

    Set-Content $nuSpecFile -Value $nuSpec
}

$currentDir = (Get-Location).Path
UpdateAssemblyInfoWithBuildNumber(Join-Path $currentDir "SolutionAssemblyInfo.cs")
UpdateNuSpecWithBuildNumber(Join-Path $currentDir "Compute.Client\Compute.Client.nuspec")

