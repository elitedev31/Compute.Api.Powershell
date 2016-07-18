Import-Module CaaS
$commands = Get-Command -Module CaaS

if((Test-Path ".\docs\powershell\") -eq 0){
    mkdir ".\docs\powershell\"}
foreach ($command in $commands){
	.\Get-HelpToRst.ps1 $command.name | Set-Content -Encoding utf8 .\docs\powershell\$command.rst
}
$modPath = $Env:PSModulePath.split(';')[1]
