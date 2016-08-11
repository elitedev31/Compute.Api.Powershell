Get-CaasNatRule
===================

Synopsis
--------


Get-CaasNatRule -NetworkDomain <NetworkDomainType> [-State <string>] [-InternalIp <string>] [-ExternalIp <string>] [-NatRuleId <guid>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasNatRule -Network <NetworkWithLocationsNetwork> [-Name <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                            

----------                                                                                                                                                                                                            

{@{name=Get-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Get-CaasNatRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-ExternalIp <string>
~~~~~~~~~

The firewall external IP

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false

 
-InternalIp <string>
~~~~~~~~~

The firewall internal IP

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false

 
-Name <string>
~~~~~~~~~

Name to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false

 
-NatRuleId <guid>
~~~~~~~~~

The NAT rule id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to show the images from

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

 
-OrderBy <string>
~~~~~~~~~

The Order By of the results, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PageNumber <int>
~~~~~~~~~

The Page Number of the result page, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PageSize <int>
~~~~~~~~~

The Page Size of the result page, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-State <string>
~~~~~~~~~

The NAT rule state

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.NatRuleType
DD.CBU.Compute.Api.Contracts.Network.NatRuleType


NOTES
-----



EXAMPLES
---------

