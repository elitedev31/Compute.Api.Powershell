New-CaasServerNic
===================

## SYNOPSIS

New-CaasServerNic -Server <ServerType> -Vlan <VlanType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerNic -Server <ServerType> -PrimaryPrivateIp <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerNic -ServerId <string> -Vlan <VlanType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerNic -ServerId <string> -PrimaryPrivateIp <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                                                                                                                                                                                                                          

----------                                                                                                                                                                                                                                                                                                                                                                                                                                          

{@{name=New-CaasServerNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -PrimaryPrivateIp &lt;string&gt;
The private network private IP address that will be assigned to the machine.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Server_PrivateIp, ServerId_PrivateIp
Aliases                      None
Dynamic?                     false
```
 
### -Server &lt;ServerType&gt;
The server on which the nic will be deployed
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           Server_Vlan, Server_PrivateIp
Aliases                      None
Dynamic?                     false
```
 
### -ServerId &lt;string&gt;
The server ID
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           ServerId_Vlan, ServerId_PrivateIp
Aliases                      None
Dynamic?                     false
```
 
### -Vlan &lt;VlanType&gt;
The server's primary network
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           ServerId_Vlan, Server_Vlan
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
