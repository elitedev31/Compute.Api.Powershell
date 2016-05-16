Get-CaasReservePrivateIpv4Address
===================

## SYNOPSIS

Get-CaasReservePrivateIpv4Address [-Vlan <VlanType>] [-VlanId <guid>] [-IpAddress <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasReservePrivateIpv4Address [-Network <NetworkWithLocationsNetwork>] [-NetworkId <guid>] [-IpAddress <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                                

----------                                                                                                                                                                                                                                                

{@{name=Get-CaasReservePrivateIpv4Address; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Get-CaasReservePrivateIpv4Address; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -IpAddress &lt;string&gt;
Identifies an individual Private IPV4
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
Identifies Cloud Network (MCP 1.0)
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           With_Network
Aliases                      None
Dynamic?                     false
```
 
### -NetworkId &lt;guid&gt;
Identifies Cloud Network (MCP 1.0)
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           With_Network
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
 
### -Vlan &lt;VlanType&gt;
Identifies VLAN (MCP 2.0)
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           With_Vlan
Aliases                      None
Dynamic?                     false
```
 
### -VlanId &lt;guid&gt;
Identifies VLAN (MCP 2.0)
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           With_Vlan
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.VlanType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ReservedPrivateIpv4AddressType


## NOTES


## EXAMPLES
