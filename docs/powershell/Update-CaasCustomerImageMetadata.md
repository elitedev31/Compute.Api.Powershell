Update-CaasCustomerImageMetadata
===================

## SYNOPSIS

Update-CaasCustomerImageMetadata -CustomerImage <CustomerImageType> [-Description <string>] [-CpuSpeed <string>] [-OperatingSystemId <string>] [-DiskSpeeds <ImageMetadataTypeDisk[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Update-CaasCustomerImageMetadata -ImageId <guid> [-Description <string>] [-CpuSpeed <string>] [-OperatingSystemId <string>] [-DiskSpeeds <ImageMetadataTypeDisk[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                              

----------                                                                                                                                                                                                                                              

{@{name=Update-CaasCustomerImageMetadata; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Update-CaasCustomerImageMetadata; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -CpuSpeed &lt;string&gt;
The cpu speed of the customer image
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -CustomerImage &lt;CustomerImageType&gt;
The customer image
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           CustomerImage
Aliases                      None
Dynamic?                     false
```
 
### -Description &lt;string&gt;
The description of the customer image
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -DiskSpeeds &lt;ImageMetadataTypeDisk[]&gt;
The disk details of the customer image
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -ImageId &lt;guid&gt;
The id of the customer image
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           CustomerImageId
Aliases                      None
Dynamic?                     false
```
 
### -OperatingSystemId &lt;string&gt;
The id of the operating system
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.CustomerImageType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
