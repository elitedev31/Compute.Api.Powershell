Get-CaasNatRule
===================

## SYNOPSIS

Get-CaasNatRule -NetworkDomain <NetworkDomainType> [-State <string>] [-InternalIp <string>] [-ExternalIp <string>] [-NatRuleId <guid>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasNatRule -Network <NetworkWithLocationsNetwork> [-Name <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                            

----------                                                                                                                                                                                                            

{@{name=Get-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Get-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -ExternalIp &lt;string&gt;
The firewall external IP
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -InternalIp &lt;string&gt;
The firewall internal IP
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
Name to filter
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false
```
 
### -NatRuleId &lt;guid&gt;
The NAT rule id
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network to show the images from
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network domain
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -State &lt;string&gt;
The NAT rule state
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.NatRuleType
DD.CBU.Compute.Api.Contracts.Network.NatRuleType


## NOTES


## EXAMPLES
