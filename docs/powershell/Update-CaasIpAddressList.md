Update-CaasIpAddressList
===================

## SYNOPSIS

Update-CaasIpAddressList -Id <guid> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Update-CaasIpAddressList -IpAddressList <IpAddressListType> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                              

----------                                                                                                                                                                                                                              

{@{name=Update-CaasIpAddressList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Update-CaasIpAddressList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -ChildIpAddressList &lt;IpAddressListType[]&gt;
Define one or more individual IP Address Lists on the same Network Domain
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -ChildIpAddressListId &lt;string[]&gt;
Define one or more individual IP Address Lists on the same Network Domain
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
 
### -Description &lt;string&gt;
The IP Address List description
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Id &lt;guid&gt;
The IP address list id
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           With_IpAddressListId
Aliases                      None
Dynamic?                     false
```
 
### -IpAddress &lt;IpAddressListRangeType[]&gt;
Define one or more individual IP addresses or ranges of IP addresses. Use New-CaasIpAddressRangeType create to create type
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -IpAddressList &lt;IpAddressListType&gt;
The IP address list
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           With_IpAddressList
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.IpAddressListType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
