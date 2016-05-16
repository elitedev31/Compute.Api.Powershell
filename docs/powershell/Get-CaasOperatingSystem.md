Get-CaasOperatingSystem
===================

## SYNOPSIS

Get-CaasOperatingSystem -DataCenterId <string> [-Name <string>] [-OperatingSystemId <string>] [-OperatingSystemFamily <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                         

----------                                                                                                         

{@{name=Get-CaasOperatingSystem; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -DataCenterId &lt;string&gt;
The Data center Id/location for figuring out the operating systems supported
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
The Os image name
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false
```
 
### -OperatingSystemFamily &lt;string&gt;
The Os family like : Unix
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false
```
 
### -OperatingSystemId &lt;string&gt;
The Os id, eg : CENTOS5/32
```
Position?                    Named
Accept pipeline input?       true (ByValue)
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

## INPUTS
System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.OperatingSystemType


## NOTES


## EXAMPLES
