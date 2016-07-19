
New-CaasPersistenceProfile
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasPersistenceProfile -Network <NetworkWithLocationsNetwork> -Name <string> -ServerFarm <ServerFarm> -TimeoutMinutes <int> -Direction <PersistenceProfileDirection> -Netmask <string> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasPersistenceProfile -Network <NetworkWithLocationsNetwork> -Name <string> -ServerFarm <ServerFarm> -TimeoutMinutes <int> -CookieName <string> -CookieType <PersistenceProfileCookieType> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-CookieName <string>
~~~~~~~~~

For HTTP_COOKIE only.The name of the cookie for the persistence profile

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           HttpCookie     Aliases                      None     Dynamic?                     false





-CookieType <PersistenceProfileCookieType>
~~~~~~~~~

For HTTP_COOKIE only.The HTTP cookie type for the persistence profile

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           HttpCookie     Aliases                      None     Dynamic?                     false





-Direction <PersistenceProfileDirection>
~~~~~~~~~

For IP_NETMASK only.The direction for the persistence profile

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           IpNetMask     Aliases                      None     Dynamic?                     false





-Name <string>
~~~~~~~~~

The name for the persistence profile

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Netmask <string>
~~~~~~~~~

For IP_NETMASK only.The netmask for the persistence profile

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           IpNetMask     Aliases                      None     Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to manage the VIP settings

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PassThru <switch>
~~~~~~~~~

Return the Probe object

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ServerFarm <ServerFarm>
~~~~~~~~~

The server farm for the persistence profile

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-TimeoutMinutes <int>
~~~~~~~~~

The timeout in munites to the profile.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Vip.ServerFarm
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Vip.PersistenceProfile


Notes
-----



Examples
---------


