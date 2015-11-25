New-CaasVIPVirtualListener
===================

## SYNOPSIS

New-CaasVIPVirtualListener -NetworkDomain <NetworkDomainType> -Name <string> -Type <string> -Protocol <AclProtocolType> -IPAddress <string> -ConnectionLimit <int> -ConnectionRateLimit <int> [-Description <string>] [-Port <int>] [-Enabled <bool>] [-SourcePortPreservation <string>] [-PoolId <string>] [-ClientClonePoolId <string>] [-PersistenceProfileId <string>] [-FallbackPersistenceProfileId <string>] [-OptimizationProfileId <string>] [-iRuleId <string[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                            

----------                                                                                                            

{@{name=New-CaasVIPVirtualListener; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -ClientClonePoolId &lt;string&gt;
The VIP virtual listener Client Clone Pool Id
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
 
### -ConnectionLimit &lt;int&gt;
The VIP virtual listener Connection Limit
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -ConnectionRateLimit &lt;int&gt;
The VIP virtual listener Connection Rate Limit
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Description &lt;string&gt;
The virtual listener description
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Enabled &lt;bool&gt;
The VIP virtual listener Status
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -FallbackPersistenceProfileId &lt;string&gt;
The VIP virtual listener Fallback Persistence Profile Id
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -IPAddress &lt;string&gt;
The VIP virtual listener IP Address
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
The virtual listener name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -NetworkDomain &lt;NetworkDomainType&gt;
The network domain
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -OptimizationProfileId &lt;string&gt;
The VIP virtual listener Optimization Profile Id
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PersistenceProfileId &lt;string&gt;
The VIP virtual listener Persistence Profile Id
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PoolId &lt;string&gt;
The VIP virtual listener Pool Id
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Port &lt;int&gt;
The VIP virtual listener Port
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Protocol &lt;AclProtocolType&gt;
The VIP virtual listener Protocol
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -SourcePortPreservation &lt;string&gt;
The VIP virtual listener Source Port Preservation
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Type &lt;string&gt;
The VIP virtual listener IP Type
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -iRuleId &lt;string[]&gt;
The VIP virtual listener iRule Ids
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
