
Remove-CaasServerFarm
===================

Synopsis
--------

.. code-block:: powershell
    
    
Remove-CaasServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]





Description
-----------



Parameters
----------




-Confirm <switch>
~~~~~~~~~



* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      cf
* Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
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





-ServerFarm <ServerFarm>
~~~~~~~~~

The server farm to be deleted

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-WhatIf <switch>
~~~~~~~~~



* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      wi
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Vip.ServerFarm
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


