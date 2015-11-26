Get-CaasCustomerImageExportHistory
===================

## SYNOPSIS

Get-CaasCustomerImageExportHistory [-RecordsToReturn <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                    

----------                                                                                                                    

{@{name=Get-CaasCustomerImageExportHistory; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -RecordsToReturn &lt;int&gt;
Number of records to return, max 100.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Image.ImageExportRecord[]


## NOTES


## EXAMPLES
