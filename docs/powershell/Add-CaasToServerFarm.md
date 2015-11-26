Add-CaasToServerFarm
===================

## SYNOPSIS

Add-CaasToServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -RealServer <RealServer> [-RealServerPort <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Add-CaasToServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -Probe <Probe> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                      

----------                                                                                                                                                                                                                      

{@{name=Add-CaasToServerFarm; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Add-CaasToServerFarm; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network to manage the VIP settings
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Probe &lt;Probe&gt;
The probe to be added to the server farm
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Probe
Aliases                      None
Dynamic?                     false
```
 
### -RealServer &lt;RealServer&gt;
The real server to be added to the server farm
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           RealServer
Aliases                      None
Dynamic?                     false
```
 
### -RealServerPort &lt;int&gt;
The real server port to be added to the server farm
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           RealServer
Aliases                      None
Dynamic?                     false
```
 
### -ServerFarm &lt;ServerFarm&gt;
The server farm that will get added a probe or real server
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Vip.ServerFarm
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
System.Object

## NOTES


## EXAMPLES
