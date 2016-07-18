Remove-CaasReserveIPv6Address
===================

Synopsis
--------


Remove-CaasReserveIPv6Address -VlanId <guid> -IpAddress <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                               

----------                                                                                                               

{@{name=Remove-CaasReserveIPv6Address; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-Connection &lt;ComputeServiceConnection&gt;
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IpAddress &lt;string&gt;
~~~~~~~~~

The IPv6 address

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-VlanId &lt;guid&gt;
~~~~~~~~~

The unique identifier of MCP 2.0 VLAN

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue, ByPropertyName)
Parameter set name           (All)
Aliases                      Id
Dynamic?                     false


INPUTS
------

System.Guid
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

