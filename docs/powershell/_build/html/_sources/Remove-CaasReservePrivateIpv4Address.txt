Remove-CaasReservePrivateIpv4Address
===================

Synopsis
--------


Remove-CaasReservePrivateIpv4Address -VlanId <guid> -IpAddress <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Remove-CaasReservePrivateIpv4Address -NetworkId <guid> -IpAddress <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Remove-CaasReservePrivateIpv4Address -Vlan <VlanType> -IpAddress <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Remove-CaasReservePrivateIpv4Address -Network <NetworkWithLocationsNetwork> -IpAddress <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         

----------                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         

{@{name=Remove-CaasReservePrivateIpv4Address; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasReservePrivateIpv4Address; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasReservePrivateIpv4Address; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasReservePrivateIpv4Address; CommonParameters=True; WorkflowCommonParameters=False; parameter=S...


Description
-----------



Parameters
----------

-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IpAddress <string>
~~~~~~~~~

The IPv4 address

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

Identifies Cloud Network (MCP 1.0)

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           With_Network
Aliases                      None
Dynamic?                     false

 
-NetworkId <guid>
~~~~~~~~~

The unique identifier of an MCP 1.0 Cloud Network

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_NetworkId
Aliases                      None
Dynamic?                     false

 
-Vlan <VlanType>
~~~~~~~~~

Identifies VLAN (MCP 2.0)

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           With_Vlan
Aliases                      None
Dynamic?                     false

 
-VlanId <guid>
~~~~~~~~~

The unique identifier of MCP 2.0 VLAN

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_VlanId
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.VlanType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

