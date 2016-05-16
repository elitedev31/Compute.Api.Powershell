Remove-CaasTag
===================

## SYNOPSIS

Remove-CaasTag -AssetType <AssetType> -AssetId <string> -TagKeyName <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Remove-CaasTag -AssetType <AssetType> -AssetId <string> -TagKeyId <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                          

----------                                                                                                                                                                                                          

{@{name=Remove-CaasTag; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasTag; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -AssetId &lt;string&gt;
The UUID of the asset
```
Position?                    Named
Accept pipeline input?       true (ByValue, ByPropertyName)
Parameter set name           (All)
Aliases                      Id
Dynamic?                     false
```
 
### -AssetType &lt;AssetType&gt;
The Asset type
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
 
### -TagKeyId &lt;string&gt;
Value of tagKey Id elements.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           With_TagKeyId
Aliases                      None
Dynamic?                     false
```
 
### -TagKeyName &lt;string&gt;
Value of tagKey Name elements.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           With_TagKeyName
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
