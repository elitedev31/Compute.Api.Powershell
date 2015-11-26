Set-CaasServerDiskDetails
===================

## SYNOPSIS

Set-CaasServerDiskDetails -ServerDetails <CaasServerDetails> -ScsiId <string> [-SpeedId <string>] [<CommonParameters>]

Set-CaasServerDiskDetails -ServerDetails <CaasServerDetails> -ScsiId <string> [-Speed <DiskSpeedType>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                

----------                                                                                                                                                                                                                                

{@{name=Set-CaasServerDiskDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Set-CaasServerDiskDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -ScsiId &lt;string&gt;
SCSI ID from the OS or customer image
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -ServerDetails &lt;CaasServerDetails&gt;
The server details created by New-CaasServerDetails
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Speed &lt;DiskSpeedType&gt;
The disk speed
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           DiskSpeedType
Aliases                      None
Dynamic?                     false
```
 
### -SpeedId &lt;string&gt;
The speedId of the new disk. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           SpeedId
Aliases                      None
Dynamic?                     false
```

## INPUTS
None


## OUTPUTS
DD.CBU.Compute.Powershell.CaasServerDetails


## NOTES


## EXAMPLES
