
New-CaasNatRule
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasNatRule -NetworkDomain <NetworkDomainType> -InternalIP <string> -ExternalIP <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasNatRule -Network <NetworkWithLocationsNetwork> -NatRuleName <string> [-SourceIpAddress <ipaddress>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-ExternalIP <string>
~~~~~~~~~

The Firewall rule name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





-InternalIP <string>
~~~~~~~~~

The Firewall rule name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





-NatRuleName <string>
~~~~~~~~~

The NAT Rule name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP1
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The target network to add the NAT rule into.

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           MCP1
* Aliases                      None
* Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





-SourceIpAddress <ipaddress>
~~~~~~~~~

The source IP Address.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP1
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network.NatRuleType
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


