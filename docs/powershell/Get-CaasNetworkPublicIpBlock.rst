
Get-CaasNetworkPublicIpBlock
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasNetworkPublicIpBlock -Network <NetworkWithLocationsNetwork> [-BaseIp <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasNetworkPublicIpBlock -NetworkDomain <NetworkDomainType> [-BaseIp <string>] [-Id <guid>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-BaseIp <string>
~~~~~~~~~

Filter the list based on the based public Ip block

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Id <guid>
~~~~~~~~~

Public Ip block id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to get the public ip addresses

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           MCP1
* Aliases                      None
* Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain to get the public ip addresses

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





-OrderBy <string>
~~~~~~~~~

The Order By of the results, only supported for MCP2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PageNumber <int>
~~~~~~~~~

The Page Number of the result page, only supported for MCP2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PageSize <int>
~~~~~~~~~

The Page Size of the result page, only supported for MCP2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network.IpBlockType
DD.CBU.Compute.Api.Contracts.Network20.PublicIpBlockType


Notes
-----



Examples
---------


