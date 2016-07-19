
Get-CaasReservePrivateIpv4Address
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasReservePrivateIpv4Address [-Vlan <VlanType>] [-VlanId <guid>] [-IpAddress <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasReservePrivateIpv4Address [-Network <NetworkWithLocationsNetwork>] [-NetworkId <guid>] [-IpAddress <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-IpAddress <string>
~~~~~~~~~

Identifies an individual Private IPV4

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

Identifies Cloud Network (MCP 1.0)

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           With_Network     Aliases                      None     Dynamic?                     false





-NetworkId <guid>
~~~~~~~~~

Identifies Cloud Network (MCP 1.0)

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_Network     Aliases                      None     Dynamic?                     false





-OrderBy <string>
~~~~~~~~~

The Order By of the results, only supported for MCP2

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PageNumber <int>
~~~~~~~~~

The Page Number of the result page, only supported for MCP2

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PageSize <int>
~~~~~~~~~

The Page Size of the result page, only supported for MCP2

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Vlan <VlanType>
~~~~~~~~~

Identifies VLAN (MCP 2.0)

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           With_Vlan     Aliases                      None     Dynamic?                     false





-VlanId <guid>
~~~~~~~~~

Identifies VLAN (MCP 2.0)

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_Vlan     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.VlanType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ReservedPrivateIpv4AddressType


Notes
-----



Examples
---------


