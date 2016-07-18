New-CaasNatRule
===================

Synopsis
--------


New-CaasNatRule -NetworkDomain <NetworkDomainType> -InternalIP <string> -ExternalIP <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasNatRule -Network <NetworkWithLocationsNetwork> -NatRuleName <string> [-SourceIpAddress <ipaddress>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                            

----------                                                                                                                                                                                                            

{@{name=New-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-ExternalIP <string>
~~~~~~~~~

The Firewall rule name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false

 
-InternalIP <string>
~~~~~~~~~

The Firewall rule name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false

 
-NatRuleName <string>
~~~~~~~~~

The NAT Rule name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The target network to add the NAT rule into.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false

 
-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false

 
-SourceIpAddress <ipaddress>
~~~~~~~~~

The source IP Address.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network.NatRuleType
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

