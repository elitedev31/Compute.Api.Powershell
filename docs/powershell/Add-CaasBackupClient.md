Add-CaasBackupClient
===================

## SYNOPSIS

Add-CaasBackupClient -Server <ServerType> -StoragePolicy <BackupStoragePolicy> -SchedulePolicy <BackupSchedulePolicy> -ClientType <BackupClientType> [-Trigger <TriggerType>] [-EmailAddresses <IReadOnlyList[string]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                      

----------                                                                                                      

{@{name=Add-CaasBackupClient; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -ClientType &lt;BackupClientType&gt;
The backup client type availabe from Get-CaasBackupClientTypes cmdlet
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Connection &lt;ComputeServiceConnection&gt;
The CaaS Connection created by New-CaasConnection
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -EmailAddresses &lt;IReadOnlyList[string]&gt;
The email addresses for alerting purposes. At least one must be added when using alerting
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -SchedulePolicy &lt;BackupSchedulePolicy&gt;
The schedule policy availabe from Get-CaasBackupSchedulePolicies cmdlet
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Server &lt;ServerType&gt;
The server to add the backup client
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -StoragePolicy &lt;BackupStoragePolicy&gt;
The storage policy availabe from Get-CaasBackupStoragePolicies cmdlet
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Trigger &lt;TriggerType&gt;
The trigger type for alerting purposes
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
System.String


## NOTES


## EXAMPLES
