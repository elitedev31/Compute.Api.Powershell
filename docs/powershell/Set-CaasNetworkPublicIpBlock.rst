
Set-CaasNetworkPublicIpBlock
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasNetworkPublicIpBlock -Network <NetworkWithLocationsNetwork> -PublicIpBlock <IpBlockType> -ServerToVipConnectivity <bool> [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to set the server to Vip

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PublicIpBlock <IpBlockType>
~~~~~~~~~

The public ip block to be released

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ServerToVipConnectivity <bool>
~~~~~~~~~

Enable/Disable the server to vip connectivity on the Ip address block

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Network.IpBlockType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


