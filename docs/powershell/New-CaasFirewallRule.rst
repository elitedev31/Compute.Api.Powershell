
New-CaasFirewallRule
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasFirewallRule -NetworkDomain <NetworkDomainType> -FirewallRuleName <string> -FirewallAction <string> -IpVersion <IpVersion> -Protocol <AclProtocolType> -Source <IpAndPortType> -Destination <IpAndPortType> -Position <RulePositionType> [-RelativeToRule <FirewallRuleType>] [-Enabled <bool>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-Destination <IpAndPortType>
~~~~~~~~~

The destination IP and Port , use New-CaasIpAndPortType

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Enabled <bool>
~~~~~~~~~

Is Firewall enabled?

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-FirewallAction <string>
~~~~~~~~~

The Firewall action (Drop / Accept Decisively)

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-FirewallRuleName <string>
~~~~~~~~~

The Firewall rule name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-IpVersion <IpVersion>
~~~~~~~~~

The IP version (IPv4 / IPv6)

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Position <RulePositionType>
~~~~~~~~~

Rule position

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Protocol <AclProtocolType>
~~~~~~~~~

The protocol type

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-RelativeToRule <FirewallRuleType>
~~~~~~~~~

Rule relative position

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Source <IpAndPortType>
~~~~~~~~~

The source IP and Port , use New-CaasIpAndPortType

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


