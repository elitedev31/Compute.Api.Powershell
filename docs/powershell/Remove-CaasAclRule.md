Remove-CaasAclRule
===================

## SYNOPSIS

Remove-CaasAclRule -Network <NetworkWithLocationsNetwork> -AclRule <AclRuleType> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                    

----------                                                                                                    

{@{name=Remove-CaasAclRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -AclRule &lt;AclRuleType&gt;
The ACL rule to delete
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Confirm &lt;switch&gt;

```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      cf
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
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network that the ACL Rule exists
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -WhatIf &lt;switch&gt;

```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      wi
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Network.AclRuleType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
System.Object

## NOTES


## EXAMPLES
