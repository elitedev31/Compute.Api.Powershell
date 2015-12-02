New-CaasVip
===================

## SYNOPSIS

New-CaasVip -Network <NetworkWithLocationsNetwork> -Name <string> -ServerFarm <ServerFarm> -Port <int> -Protocol <VipProtocol> -InService <bool> -ReplyToIcmp <bool> [-IpAddress <ipaddress>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasVip -Network <NetworkWithLocationsNetwork> -Name <string> -PersistenceProfile <PersistenceProfile> -Port <int> -Protocol <VipProtocol> -InService <bool> -ReplyToIcmp <bool> [-IpAddress <ipaddress>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                    

----------                                                                                                                                                                                                    

{@{name=New-CaasVip; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasVip; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -InService &lt;bool&gt;
The Vip status
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -IpAddress &lt;ipaddress&gt;
The Vip IP address, If you do not supply an IP address, the next available public IP address from your network's public IP block(s)  will be assigned.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
The name for the VIP
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network to manage the VIP settings
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PassThru &lt;switch&gt;
Return the RealServer object
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PersistenceProfile &lt;PersistenceProfile&gt;
The persistence profile for the VIP
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           PersistenceProfile
Aliases                      None
Dynamic?                     false
```
 
### -Port &lt;int&gt;
The port to VIP. valid range 1-65535
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Protocol &lt;VipProtocol&gt;
The protocol for the VIP. valid TCP or UDP
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -ReplyToIcmp &lt;bool&gt;
The vip reply to ICMP status
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -ServerFarm &lt;ServerFarm&gt;
The server farm for the VIP
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           ServerFarm
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Vip.ServerFarm
DD.CBU.Compute.Api.Contracts.Vip.PersistenceProfile
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Vip.Vip


## NOTES


## EXAMPLES
