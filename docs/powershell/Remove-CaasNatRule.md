Remove-CaasNatRule
===================

## SYNOPSIS

Remove-CaasNatRule -NatRule <psobject> -Network <NetworkWithLocationsNetwork> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Remove-CaasNatRule -NatRule <psobject> -NetworkDomain <NetworkDomainType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                  

----------                                                                                                                                                                                                                  

{@{name=Remove-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -NatRule &lt;psobject&gt;
The NAT Rule
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network that the ACL Rule exists
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network domain that the NAT Rule exists
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false
```

## INPUTS
System.Management.Automation.PSObject
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
