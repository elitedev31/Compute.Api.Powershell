New-CaasServerDetails
===================

## SYNOPSIS

New-CaasServerDetails -Name <string> -AdminPassword <string> -IsStarted <bool> -ServerImage <ImagesWithDiskSpeedImage> -Network <NetworkWithLocationsNetwork> [-Description <string>] [<CommonParameters>]

New-CaasServerDetails -Name <string> -AdminPassword <string> -IsStarted <bool> -ServerImage <ImagesWithDiskSpeedImage> -PrimaryVlan <VlanType> -NetworkDomain <NetworkDomainType> [-Description <string>] [<CommonParameters>]

New-CaasServerDetails -Name <string> -AdminPassword <string> -IsStarted <bool> -ServerImage <ImagesWithDiskSpeedImage> -NetworkDomain <NetworkDomainType> -PrivateIp <string> [-Description <string>] [<CommonParameters>]

New-CaasServerDetails -Name <string> -AdminPassword <string> -IsStarted <bool> -ServerImage <ImagesWithDiskSpeedImage> -PrivateIp <string> [-Description <string>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                                                                                                                                                                                                                                          

----------                                                                                                                                                                                                                                                                                                                                                                                                                                                          

{@{name=New-CaasServerDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -AdminPassword &lt;string&gt;
The VM administrator password
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Description &lt;string&gt;
The description of the VM
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -IsStarted &lt;bool&gt;
Will the VM be started after deployment (true|false)
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
The VM name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network to deploy the machine to.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1_WithNetwork
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network domain in which server will be deployed
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP2_WithVlan, MCP2_WithPrivateIp
Aliases                      None
Dynamic?                     false
```
 
### -PrimaryVlan &lt;VlanType&gt;
The server's primary vlan
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2_WithVlan
Aliases                      None
Dynamic?                     false
```
 
### -PrivateIp &lt;string&gt;
The network private IP address that will be assigned to the machine.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1_WithPrivateIp, MCP2_WithPrivateIp
Aliases                      None
Dynamic?                     false
```
 
### -ServerImage &lt;ImagesWithDiskSpeedImage&gt;
The OS or Customer Server Image to use for deployment
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      OsServerImage
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType


## OUTPUTS
DD.CBU.Compute.Powershell.CaasServerDetails


## NOTES


## EXAMPLES
