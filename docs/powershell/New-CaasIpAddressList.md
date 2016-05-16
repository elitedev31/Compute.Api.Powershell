New-CaasIpAddressList
===================

## SYNOPSIS

New-CaasIpAddressList -NetworkDomainId <string> -Name <string> -IpVersion <IpVersion> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAddressList -NetworkDomain <NetworkDomainType> -Name <string> -IpVersion <IpVersion> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                        

----------                                                                                                                                                                                                                        

{@{name=New-CaasIpAddressList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasIpAddressList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -ChildIpAddressList &lt;IpAddressListType[]&gt;
The network domain id
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
 
### -IpAddress &lt;IpAddressListRangeType[]&gt;
Define one or more individual IP addresses or ranges of IP addresses. Use New CaasIpAddressRangeType to create type
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -IpVersion &lt;IpVersion&gt;
The IP version (IPv4 / IPv6)
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
The IP Address List name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network domain
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           With_NetworkDomain
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomainId &lt;string&gt;
The network domain id
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           With_NetworkDomainId
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
