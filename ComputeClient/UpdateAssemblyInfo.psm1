
Function Update-AssemblyInfoWithBuildNumber
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
    $updatedVersionInfo = $solutionAssemblyInfo -replace "Version\(`"(\d+)\.(\d+)\.(\d+)\.\d+`"\)\]`$", "Version(`"$Version`")]"

    $updatedVersionInfo | Out-File $SolutionAssemblyInfoFile
}

Function Update-NuSpecWithBuildNumber
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

export-modulemember -function Update-AssemblyInfoWithBuildNumber, Update-NuSpecWithBuildNumber

