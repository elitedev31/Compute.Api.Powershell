Remove-CaasNetworkPublicIpBlock
===================

## SYNOPSIS

Remove-CaasNetworkPublicIpBlock -Network <NetworkWithLocationsNetwork> -PublicIpBlock <psobject> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]

Remove-CaasNetworkPublicIpBlock -PublicIpBlock <psobject> -NetworkDomain <NetworkDomainType> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                            

----------                                                                                                                                                                                                                                            

{@{name=Remove-CaasNetworkPublicIpBlock; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasNetworkPublicIpBlock; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
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
The network to release the public ip addresses
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network domain to release the public ip addresses
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -PublicIpBlock &lt;psobject&gt;
The public ip block to be released
```
Position?                    Named
Accept pipeline input?       true (ByValue)
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
System.Management.Automation.PSObject
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.General.Status
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
