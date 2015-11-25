New-CaasServerOnNetworkDomain
===================

## SYNOPSIS

New-CaasServerOnNetworkDomain -NetworkDomain <NetworkDomainType> -Name <string> -ServerImage <ImagesWithDiskSpeedImage> -IsStarted <bool> -AdminPassword <string> -PrimaryVlan <VlanType> [-Description <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerOnNetworkDomain -NetworkDomain <NetworkDomainType> -Name <string> -ServerImage <ImagesWithDiskSpeedImage> -IsStarted <bool> -AdminPassword <string> -PrimaryPrivateIp <string> [-Description <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                        

----------                                                                                                                                                                                                                                        

{@{name=New-CaasServerOnNetworkDomain; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerOnNetworkDomain; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -AdminPassword &lt;string&gt;
The server VM administrator password
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
The server description
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -IsStarted &lt;bool&gt;
The server start flag
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
The server name
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network domain in which server will be deployed
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PassThru &lt;switch&gt;
Return the Server object after execution
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PrimaryPrivateIp &lt;string&gt;
The private network private IP address that will be assigned to the machine.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           PrivateIp
Aliases                      None
Dynamic?                     false
```
 
### -PrimaryVlan &lt;VlanType&gt;
The server's primary vlan
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           VlanId
Aliases                      PrimaryNetwork
Dynamic?                     false
```
 
### -ServerImage &lt;ImagesWithDiskSpeedImage&gt;
The server OS Image
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
System.String
DD.CBU.Compute.Api.Contracts.Image.ImagesWithDiskSpeedImage
System.Boolean
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ServerType


## NOTES


## EXAMPLES
