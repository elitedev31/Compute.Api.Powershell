Get-CaasNetworkPublicIpBlock
===================

## SYNOPSIS

Get-CaasNetworkPublicIpBlock -Network <NetworkWithLocationsNetwork> [-BaseIp <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasNetworkPublicIpBlock -NetworkDomain <NetworkDomainType> [-BaseIp <string>] [-Id <guid>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                      

----------                                                                                                                                                                                                                                      

{@{name=Get-CaasNetworkPublicIpBlock; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Get-CaasNetworkPublicIpBlock; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -BaseIp &lt;string&gt;
Filter the list based on the based public Ip block
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
 
### -Id &lt;guid&gt;
Public Ip block id
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network to get the public ip addresses
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network domain to get the public ip addresses
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -OrderBy &lt;string&gt;
The Order By of the results, only supported for MCP2
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PageNumber &lt;int&gt;
The Page Number of the result page, only supported for MCP2
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PageSize &lt;int&gt;
The Page Size of the result page, only supported for MCP2
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
DD.CBU.Compute.Api.Contracts.Network20.PublicIpBlockType
DD.CBU.Compute.Api.Contracts.Network.IpBlockType


## NOTES


## EXAMPLES
