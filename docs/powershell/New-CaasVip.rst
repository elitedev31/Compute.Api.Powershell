
New-CaasVip
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasVip -Network <NetworkWithLocationsNetwork> -Name <string> -ServerFarm <ServerFarm> -Port <int> -Protocol <VipProtocol> -InService <bool> -ReplyToIcmp <bool> [-IpAddress <ipaddress>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasVip -Network <NetworkWithLocationsNetwork> -Name <string> -PersistenceProfile <PersistenceProfile> -Port <int> -Protocol <VipProtocol> -InService <bool> -ReplyToIcmp <bool> [-IpAddress <ipaddress>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-InService <bool>
~~~~~~~~~

The Vip status

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-IpAddress <ipaddress>
~~~~~~~~~

The Vip IP address, If you do not supply an IP address, the next available public IP address from your network's public IP block(s)  will be assigned.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

The name for the VIP

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to manage the VIP settings

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PassThru <switch>
~~~~~~~~~

Return the RealServer object

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PersistenceProfile <PersistenceProfile>
~~~~~~~~~

The persistence profile for the VIP

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           PersistenceProfile
* Aliases                      None
* Dynamic?                     false





-Port <int>
~~~~~~~~~

The port to VIP. valid range 1-65535

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Protocol <VipProtocol>
~~~~~~~~~

The protocol for the VIP. valid TCP or UDP

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ReplyToIcmp <bool>
~~~~~~~~~

The vip reply to ICMP status

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ServerFarm <ServerFarm>
~~~~~~~~~

The server farm for the VIP

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           ServerFarm
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Vip.ServerFarm
DD.CBU.Compute.Api.Contracts.Vip.PersistenceProfile
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Vip.Vip


Notes
-----



Examples
---------


