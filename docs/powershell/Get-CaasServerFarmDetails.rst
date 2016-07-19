
Get-CaasServerFarmDetails
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasServerFarmDetails -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-ServerFarm <ServerFarm>
~~~~~~~~~

The network to manage the VIP settings

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Vip.ServerFarm
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Vip.ServerFarmDetails


Notes
-----



Examples
---------


