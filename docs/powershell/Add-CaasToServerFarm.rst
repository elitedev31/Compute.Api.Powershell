
Add-CaasToServerFarm
===================

Synopsis
--------

.. code-block:: powershell
    
    
Add-CaasToServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -RealServer <RealServer> [-RealServerPort <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Add-CaasToServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -Probe <Probe> [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to manage the VIP settings

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Probe <Probe>
~~~~~~~~~

The probe to be added to the server farm

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           Probe     Aliases                      None     Dynamic?                     false





-RealServer <RealServer>
~~~~~~~~~

The real server to be added to the server farm

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           RealServer     Aliases                      None     Dynamic?                     false





-RealServerPort <int>
~~~~~~~~~

The real server port to be added to the server farm

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           RealServer     Aliases                      None     Dynamic?                     false





-ServerFarm <ServerFarm>
~~~~~~~~~

The server farm that will get added a probe or real server

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





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


