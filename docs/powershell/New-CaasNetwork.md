New-CaasNetwork
===================

## SYNOPSIS

New-CaasNetwork -Name <string> [-Datacentre <DatacenterWithMaintenanceStatusType>] [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasNetwork -Name <string> [-Location <string>] [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                            

----------                                                                                                                                                                                                            

{@{name=New-CaasNetwork; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasNetwork; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -Datacentre &lt;DatacenterWithMaintenanceStatusType&gt;
The data centre location where the network will be deployed.
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           DataCentre
Aliases                      None
Dynamic?                     false
```
 
### -Description &lt;string&gt;
The description of the network
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Location &lt;string&gt;
The data centre location where the network will be deployed.
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           Location
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
A unique name for the new network to deploy
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Datacenter.DatacenterWithMaintenanceStatusType
System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
System.Object

## NOTES


## EXAMPLES
