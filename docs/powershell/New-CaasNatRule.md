New-CaasNatRule
===================

## SYNOPSIS

New-CaasNatRule -NetworkDomain <NetworkDomainType> -InternalIP <string> -ExternalIP <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasNatRule -Network <NetworkWithLocationsNetwork> -NatRuleName <string> [-SourceIpAddress <ipaddress>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                            

----------                                                                                                                                                                                                            

{@{name=New-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -ExternalIP &lt;string&gt;
The Firewall rule name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -InternalIP &lt;string&gt;
The Firewall rule name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```
 
### -NatRuleName &lt;string&gt;
The NAT Rule name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The target network to add the NAT rule into.
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
 
### -SourceIpAddress &lt;ipaddress&gt;
The source IP Address.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network.NatRuleType
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
