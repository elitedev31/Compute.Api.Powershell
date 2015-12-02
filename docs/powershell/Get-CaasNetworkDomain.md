Get-CaasNetworkDomain
===================

## SYNOPSIS

Get-CaasNetworkDomain [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasNetworkDomain [-NetworkDomainId <guid>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasNetworkDomain [-NetworkDomainName <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                                                                                                                         

----------                                                                                                                                                                                                                                                                                                                                         

{@{name=Get-CaasNetworkDomain; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Get-CaasNetworkDomain; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Get-CaasNetworkDomain; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -NetworkDomainId &lt;guid&gt;
NetworkDomain id
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           FilterById
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomainName &lt;string&gt;
NetworkDomain name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           FilterByName
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType[]


## NOTES


## EXAMPLES
