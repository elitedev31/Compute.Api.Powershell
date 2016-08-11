
Remove-CaasNatRule
===================

Synopsis
--------

.. code-block:: powershell
    
    
Remove-CaasNatRule -NatRule <psobject> -Network <NetworkWithLocationsNetwork> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Remove-CaasNatRule -NatRule <psobject> -NetworkDomain <NetworkDomainType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-NatRule <psobject>
~~~~~~~~~

The NAT Rule

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network that the ACL Rule exists

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           MCP1
* Aliases                      None
* Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain that the NAT Rule exists

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





Inputs
------

System.Management.Automation.PSObject
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


