Remove-CaasCustomerImage
===================

## SYNOPSIS

Remove-CaasCustomerImage -ServerImage <ImagesWithDiskSpeedImage> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                          

----------                                                                                                          

{@{name=Remove-CaasCustomerImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -Confirm &lt;switch&gt;

```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      cf
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
 
### -ServerImage &lt;ImagesWithDiskSpeedImage&gt;
The server image retrieved by Get-CaasCustomerImages
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -WhatIf &lt;switch&gt;

```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      wi
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Image.ImagesWithDiskSpeedImage
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
System.Object

## NOTES


## EXAMPLES
