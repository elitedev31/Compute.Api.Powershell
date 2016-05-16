Set-CaasVipPool
===================

## SYNOPSIS

Set-CaasVipPool -VipPool <PoolType> [-Description <string>] [-LoadBalanceMethod <string>] [-HealthMonitorId <string[]>] [-ServiceDownAction <string>] [-SlowRampTime <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                 

----------                                                                                                 

{@{name=Set-CaasVipPool; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -Description &lt;string&gt;
The VIP Pool description
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -HealthMonitorId &lt;string[]&gt;
The VIP Pool Health Monitor Ids
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -LoadBalanceMethod &lt;string&gt;
The VIP Pool Load balance method
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -ServiceDownAction &lt;string&gt;
The VIP Pool Service down action
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -SlowRampTime &lt;int&gt;
The VIP Pool Slow ramp time
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -VipPool &lt;PoolType&gt;
The Firewall Rule
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network20.PoolType
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


## NOTES


## EXAMPLES
