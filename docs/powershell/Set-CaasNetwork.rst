
Set-CaasNetwork
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasNetwork -Network <NetworkWithLocationsNetwork> [-Name <string>] [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Set-CaasNetwork -Network <NetworkWithLocationsNetwork> [-Multicast <bool>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-Description <string>
~~~~~~~~~

Set the new description for the network

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           NetworkName
* Aliases                      None
* Dynamic?                     false





-Multicast <bool>
~~~~~~~~~

Enable/Disable multicast on the network

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Multicast
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

Set new name for the network

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           NetworkName
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

Set the server name on CaaS

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


