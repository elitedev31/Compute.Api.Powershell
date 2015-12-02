New-CaasAccountRoles
===================

## SYNOPSIS

New-CaasAccountRoles [-Network <bool>] [-Server <bool>] [-Backup <bool>] [-CreateImage <bool>] [-Storage <bool>] [-Reports <bool>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasAccountRoles [-ReadOnly <bool>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                      

----------                                                                                                                                                                                                                      

{@{name=New-CaasAccountRoles; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasAccountRoles; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -Backup &lt;bool&gt;
True of False for backup role
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           SubAdministrator
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
 
### -CreateImage &lt;bool&gt;
True of False for create image role
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           SubAdministrator
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;bool&gt;
True of False for network role
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           SubAdministrator
Aliases                      None
Dynamic?                     false
```
 
### -ReadOnly &lt;bool&gt;
True of False for reports role
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           ReadOnly
Aliases                      None
Dynamic?                     false
```
 
### -Reports &lt;bool&gt;
True of False for reports role
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           SubAdministrator
Aliases                      None
Dynamic?                     false
```
 
### -Server &lt;bool&gt;
True of False for server role
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           SubAdministrator
Aliases                      None
Dynamic?                     false
```
 
### -Storage &lt;bool&gt;
True of False for storage role
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           SubAdministrator
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Directory.Role[]


## NOTES


## EXAMPLES
