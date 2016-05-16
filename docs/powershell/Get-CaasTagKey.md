Get-CaasTagKey
===================

## SYNOPSIS

Get-CaasTagKey [-TagKeyId <guid>] [-Name <string>] [-ValueRequired <bool>] [-DisplayOnReport <bool>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                

----------                                                                                                

{@{name=Get-CaasTagKey; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -DisplayOnReport &lt;bool&gt;
The displayed on reports to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
The tag key name to filter
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
Accept pipeline input?       true (ByValue)
Parameter set name           Filtered
Aliases                      Id
Dynamic?                     false
```
 
### -ValueRequired &lt;bool&gt;
The value required to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false
```

## INPUTS
System.Guid
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
