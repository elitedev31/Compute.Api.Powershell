Get-CaasTag
===================

## SYNOPSIS

Get-CaasTag [-AssetId <string>] [-AssetType <AssetType>] [-DataCenterId <string>] [-TagKeyName <string>] [-TagKeyId <guid>] [-Value <string>] [-ValueRequired <bool>] [-DisplayOnReport <bool>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                             

----------                                                                                             

{@{name=Get-CaasTag; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -AssetId &lt;string&gt;
The asset id to filter
```
Position?                    Named
Accept pipeline input?       true (ByValue, ByPropertyName)
Parameter set name           Filtered
Aliases                      Id
Dynamic?                     false
```
 
### -AssetType &lt;AssetType&gt;
The asset type to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
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
 
### -DataCenterId &lt;string&gt;
Data Center Id/ Location to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      Location
Dynamic?                     false
```
 
### -DisplayOnReport &lt;bool&gt;
The display on report
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false
```
 
### -OrderBy &lt;string&gt;
The Order By of the results, only supported for MCP2
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PageNumber &lt;int&gt;
The Page Number of the result page, only supported for MCP2
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PageSize &lt;int&gt;
The Page Size of the result page, only supported for MCP2
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -TagKeyId &lt;guid&gt;
The tag key id to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false
```
 
### -TagKeyName &lt;string&gt;
The tag key name to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false
```
 
### -Value &lt;string&gt;
The value to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false
```
 
### -ValueRequired &lt;bool&gt;
The value is required
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false
```

## INPUTS
System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
