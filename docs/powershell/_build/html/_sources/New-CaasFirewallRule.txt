New-CaasFirewallRule
===================

Synopsis
--------


New-CaasFirewallRule -NetworkDomain <NetworkDomainType> -FirewallRuleName <string> -FirewallAction <string> -IpVersion <IpVersion> -Protocol <AclProtocolType> -Source <IpAndPortType> -Destination <IpAndPortType> -Position <RulePositionType> [-RelativeToRule <FirewallRuleType>] [-Enabled <bool>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                      

----------                                                                                                      

{@{name=New-CaasFirewallRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Destination <IpAndPortType>
~~~~~~~~~

The destination IP and Port , use New-CaasIpAndPortType

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Enabled <bool>
~~~~~~~~~

Is Firewall enabled?

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-FirewallAction <string>
~~~~~~~~~

The Firewall action (Drop / Accept Decisively)

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-FirewallRuleName <string>
~~~~~~~~~

The Firewall rule name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IpVersion <IpVersion>
~~~~~~~~~

The IP version (IPv4 / IPv6)

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Position <RulePositionType>
~~~~~~~~~

Rule position

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Protocol <AclProtocolType>
~~~~~~~~~

The protocol type

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-RelativeToRule <FirewallRuleType>
~~~~~~~~~

Rule relative position

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Source <IpAndPortType>
~~~~~~~~~

The source IP and Port , use New-CaasIpAndPortType

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

