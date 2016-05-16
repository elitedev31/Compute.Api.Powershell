Remove-CaasReserveIPv6Address
===================

## SYNOPSIS

Remove-CaasReserveIPv6Address -VlanId <guid> -IpAddress <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                               

----------                                                                                                               

{@{name=Remove-CaasReserveIPv6Address; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
The IPv6 address
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -VlanId &lt;guid&gt;
The unique identifier of MCP 2.0 VLAN
```
Position?                    Named
Accept pipeline input?       true (ByValue, ByPropertyName)
Parameter set name           (All)
Aliases                      Id
Dynamic?                     false
```

## INPUTS
System.Guid
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
