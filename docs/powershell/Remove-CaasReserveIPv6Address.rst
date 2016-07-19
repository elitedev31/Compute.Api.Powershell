
Remove-CaasReserveIPv6Address
===================

Synopsis
--------

.. code-block:: powershell
    
    
Remove-CaasReserveIPv6Address -VlanId <guid> -IpAddress <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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

The IPv6 address

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-VlanId <guid>
~~~~~~~~~

The unique identifier of MCP 2.0 VLAN

* Position?                    Named
* Accept pipeline input?       true (ByValue, ByPropertyName)
* Parameter set name           (All)
* Aliases                      Id
* Dynamic?                     false





Inputs
------

System.Guid
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


