Get-CaasBackupSchedulePolicies
===================

## SYNOPSIS

Get-CaasBackupSchedulePolicies -Server <ServerType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                

----------                                                                                                                

{@{name=Get-CaasBackupSchedulePolicies; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -Connection &lt;ComputeServiceConnection&gt;
The CaaS Connection created by New-CaasConnection
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Server &lt;ServerType&gt;
The server associated with the backup schedule policies
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Backup.BackupSchedulePolicy


## NOTES


## EXAMPLES
