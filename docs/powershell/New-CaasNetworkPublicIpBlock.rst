
New-CaasNetworkPublicIpBlock
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasNetworkPublicIpBlock -Network <NetworkWithLocationsNetwork> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasNetworkPublicIpBlock -NetworkDomain <NetworkDomainType> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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

The network to add the public ip addresses

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           MCP1
* Aliases                      None
* Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network to add the public ip addresses

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





-PassThru <switch>
~~~~~~~~~

Return the IpBlockType object

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

DD.CBU.Compute.Api.Contracts.Network20.PublicIpBlockType
DD.CBU.Compute.Api.Contracts.Network.IpBlockType


Notes
-----



Examples
---------


