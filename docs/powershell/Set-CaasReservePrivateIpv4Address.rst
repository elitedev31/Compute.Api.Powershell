
Set-CaasReservePrivateIpv4Address
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasReservePrivateIpv4Address -VlanId <guid> [-IpAddress <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Set-CaasReservePrivateIpv4Address -NetworkId <guid> [-IpAddress <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Set-CaasReservePrivateIpv4Address -Vlan <VlanType> [-IpAddress <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Set-CaasReservePrivateIpv4Address -Network <NetworkWithLocationsNetwork> [-IpAddress <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-IpAddress <string>
~~~~~~~~~

The IPv4 address

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

Identifies Cloud Network (MCP 1.0)

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           With_Network
* Aliases                      None
* Dynamic?                     false





-NetworkId <guid>
~~~~~~~~~

The unique identifier of an MCP 1.0 Cloud Network

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           With_NetworkId
* Aliases                      None
* Dynamic?                     false





-Vlan <VlanType>
~~~~~~~~~

Identifies VLAN (MCP 2.0)

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           With_Vlan
* Aliases                      None
* Dynamic?                     false





-VlanId <guid>
~~~~~~~~~

The unique identifier of MCP 2.0 VLAN

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           With_VlanId
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.VlanType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


