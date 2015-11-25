New-CaasPersistenceProfile
===================

## SYNOPSIS

New-CaasPersistenceProfile -Network <NetworkWithLocationsNetwork> -Name <string> -ServerFarm <ServerFarm> -TimeoutMinutes <int> -Direction <PersistenceProfileDirection> -Netmask <string> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasPersistenceProfile -Network <NetworkWithLocationsNetwork> -Name <string> -ServerFarm <ServerFarm> -TimeoutMinutes <int> -CookieName <string> -CookieType <PersistenceProfileCookieType> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                  

----------                                                                                                                                                                                                                                  

{@{name=New-CaasPersistenceProfile; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasPersistenceProfile; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
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
 
### -CookieName &lt;string&gt;
For HTTP_COOKIE only.The name of the cookie for the persistence profile
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           HttpCookie
Aliases                      None
Dynamic?                     false
```
 
### -CookieType &lt;PersistenceProfileCookieType&gt;
For HTTP_COOKIE only.The HTTP cookie type for the persistence profile
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           HttpCookie
Aliases                      None
Dynamic?                     false
```
 
### -Direction &lt;PersistenceProfileDirection&gt;
For IP_NETMASK only.The direction for the persistence profile
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           IpNetMask
Aliases                      None
Dynamic?                     false
```
 
### -Name &lt;string&gt;
The name for the persistence profile
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Netmask &lt;string&gt;
For IP_NETMASK only.The netmask for the persistence profile
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           IpNetMask
Aliases                      None
Dynamic?                     false
```
 
### -Network &lt;NetworkWithLocationsNetwork&gt;
The network to manage the VIP settings
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PassThru &lt;switch&gt;
Return the Probe object
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -ServerFarm &lt;ServerFarm&gt;
The server farm for the persistence profile
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -TimeoutMinutes &lt;int&gt;
The timeout in munites to the profile.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Vip.ServerFarm
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
DD.CBU.Compute.Api.Contracts.Vip.PersistenceProfile


## NOTES


## EXAMPLES
