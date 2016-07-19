
Get-CaasNatRule
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasNatRule -NetworkDomain <NetworkDomainType> [-State <string>] [-InternalIp <string>] [-ExternalIp <string>] [-NatRuleId <guid>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasNatRule -Network <NetworkWithLocationsNetwork> [-Name <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-ExternalIp <string>
~~~~~~~~~

The firewall external IP

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





-InternalIp <string>
~~~~~~~~~

The firewall internal IP

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

Name to filter

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP1
* Aliases                      None
* Dynamic?                     false





-NatRuleId <guid>
~~~~~~~~~

The NAT rule id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to show the images from

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





-State <string>
~~~~~~~~~

The NAT rule state

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP2
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.NatRuleType
DD.CBU.Compute.Api.Contracts.Network.NatRuleType


Notes
-----



Examples
---------


