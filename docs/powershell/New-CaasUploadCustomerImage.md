New-CaasUploadCustomerImage
===================

## SYNOPSIS

New-CaasUploadCustomerImage -Ovf <string> -VirtualImage <string> [-Manifest <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasUploadCustomerImage -VirtualAppliance <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                    

----------                                                                                                                                                                                                                                    

{@{name=New-CaasUploadCustomerImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasUploadCustomerImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -Manifest &lt;string&gt;
The path to the manifest file
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           IndividualFiles
Aliases                      None
Dynamic?                     false
```
 
### -Ovf &lt;string&gt;
The path to the OVF file.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           IndividualFiles
Aliases                      None
Dynamic?                     false
```
 
### -VirtualAppliance &lt;string&gt;
The path to an OVA (Virtual Appliance) file.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Appliance
Aliases                      None
Dynamic?                     false
```
 
### -VirtualImage &lt;string&gt;
The path to the virtual image (e.g. VMDK, VHD) file.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           IndividualFiles
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Server.ServerImageWithStateType


## NOTES


## EXAMPLES
