Set-CaasFirewallRule
===================

Synopsis
--------


Set-CaasFirewallRule -FirewallRule <FirewallRuleType> -Enabled <bool> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                      

----------                                                                                                      

{@{name=Set-CaasFirewallRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Enabled <bool>
~~~~~~~~~

Is Firewall enabled?

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-FirewallRule <FirewallRuleType>
~~~~~~~~~

The Firewall Rule

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.FirewallRuleType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

