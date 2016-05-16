Get-CaasServer
===================

## SYNOPSIS

Get-CaasServer [[-Name] <string>] [-ServerId <guid>] [-Network <NetworkWithLocationsNetwork>] [-NetworkDomain <NetworkDomainType>] [-NetworkDomainId <string>] [-Vlan <VlanType>] [-VlanId <string>] [-Location <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                

----------                                                                                                

{@{name=Get-CaasServer; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -Location &lt;string&gt;
Location of the server to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
Name of the server to filter
```
Position?                    0
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network to show the servers from
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network domain to show the servers from
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomainId &lt;string&gt;
The network domain to show the servers from
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
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
 
### -ServerId &lt;guid&gt;
Server id  to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Vlan &lt;VlanType&gt;
The VLAN to filter by
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -VlanId &lt;string&gt;
The VLAN ID to filter by
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ServerType


## NOTES


## EXAMPLES
