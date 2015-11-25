New-CaasAclRule
===================

## SYNOPSIS

New-CaasAclRule -Network <NetworkWithLocationsNetwork> -AclRuleName <string> -Position <int> -Action <AclActionType> -Protocol <AclProtocolType> [-SourceIpAddress <ipaddress>] [-SourceNetmask <ipaddress>] [-DestinationIpAddress <ipaddress>] [-DestinationNetmask <ipaddress>] [-PortRangeType <PortRangeTypeType>] [-Port1 <int>] [-Port2 <int>] [-AclType <AclType>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                 

----------                                                                                                 

{@{name=New-CaasAclRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -AclRuleName &lt;string&gt;
The ACL Rule name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -AclType &lt;AclType&gt;
The type of the ACL. One of OUTSIDE_ACL or INSIDE_ACL. Default is OUTSIDE_ACL.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Action &lt;AclActionType&gt;
The ACL action type: Permit or Deny
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
 
### -DestinationIpAddress &lt;ipaddress&gt;
The destination IP Address. If not supplied, ANY IP address is assumed.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -DestinationNetmask &lt;ipaddress&gt;
The destination Netmask. If supplied with the DestinationIpAddress, represents CIDR boundary for the network.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The target network to add the ACL rule into.
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Port1 &lt;int&gt;
Depending on the port range type - will define the port criteria
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Port2 &lt;int&gt;
Depending on the port range type - will define the port criteria
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PortRangeType &lt;PortRangeTypeType&gt;
The port range type
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Position &lt;int&gt;
The position of the ACL rule to add
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Protocol &lt;AclProtocolType&gt;
The protocol
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -SourceIpAddress &lt;ipaddress&gt;
The source IP Address. If not supplied, ANY IP address is assumed.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -SourceNetmask &lt;ipaddress&gt;
The source Netmask. If supplied with the SourceIpAddress, represents CIDR boundary for the network.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network.AclRuleType


## NOTES


## EXAMPLES
