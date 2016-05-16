Get-CaasNetworkConfiguration
===================

## SYNOPSIS

Get-CaasNetworkConfiguration -Network <NetworkWithLocationsNetwork> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                              

----------                                                                                                              

{@{name=Get-CaasNetworkConfiguration; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
Set the server name on CaaS
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network.NetworkConfigurationType


## NOTES


## EXAMPLES
