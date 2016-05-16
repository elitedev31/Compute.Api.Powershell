Get-CaasNic
===================

## SYNOPSIS

Get-CaasNic -Vlan <VlanType> [-Id <guid>] [-ServerId <guid>] [-SecurityGroupId <guid>] [-IsPartOfSecurityGroup <bool>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasNic -VlanId <guid> [-Id <guid>] [-ServerId <guid>] [-SecurityGroupId <guid>] [-IsPartOfSecurityGroup <bool>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                    

----------                                                                                                                                                                                                    

{@{name=Get-CaasNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Get-CaasNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -Id &lt;guid&gt;
Identifies an individual NIC
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -IsPartOfSecurityGroup &lt;bool&gt;
Indicates whether or not the given NIC is or is not part of a Security Group
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
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
 
### -SecurityGroupId &lt;guid&gt;
Identifies NICs in an individual Security Group
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -ServerId &lt;guid&gt;
Identifies NICs on an individual Server
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Vlan &lt;VlanType&gt;
Identifies NICs on an individual VLAN
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           With_VLan
Aliases                      None
Dynamic?                     false
```
 
### -VlanId &lt;guid&gt;
Identifies NICs on an individual VLAN
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           With_VLanId
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.VlanType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.NicWithSecurityGroupType


## NOTES


## EXAMPLES
