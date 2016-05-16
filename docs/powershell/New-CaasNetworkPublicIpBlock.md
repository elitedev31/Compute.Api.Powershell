New-CaasNetworkPublicIpBlock
===================

## SYNOPSIS

New-CaasNetworkPublicIpBlock -Network <NetworkWithLocationsNetwork> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasNetworkPublicIpBlock -NetworkDomain <NetworkDomainType> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                      

----------                                                                                                                                                                                                                                      

{@{name=New-CaasNetworkPublicIpBlock; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasNetworkPublicIpBlock; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network to add the public ip addresses
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network to add the public ip addresses
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -PassThru &lt;switch&gt;
Return the IpBlockType object
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network.IpBlockType
DD.CBU.Compute.Api.Contracts.Network20.PublicIpBlockType


## NOTES


## EXAMPLES
