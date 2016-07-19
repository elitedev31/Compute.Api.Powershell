
Remove-CaasFromServerFarm
===================

Synopsis
--------

.. code-block:: powershell
    
    
Remove-CaasFromServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -RealServer <RealServer> [-RealServerPort <int>] [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]

Remove-CaasFromServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -Probe <Probe> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]





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





-Probe <Probe>
~~~~~~~~~

The probe to be removed to the server farm

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Probe
* Aliases                      None
* Dynamic?                     false





-RealServer <RealServer>
~~~~~~~~~

The real server to be removed to the server farm

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           RealServer
* Aliases                      None
* Dynamic?                     false





-RealServerPort <int>
~~~~~~~~~

The real server port to be removed to the server farm

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           RealServer
* Aliases                      None
* Dynamic?                     false





-ServerFarm <ServerFarm>
~~~~~~~~~

The server farm that will get removed a probe or real server

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


