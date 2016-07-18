Get-CaasAclRules
===================

Synopsis
--------


Get-CaasAclRules [[-Name] <string>] -Network <NetworkWithLocationsNetwork> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                  

----------                                                                                                  

{@{name=Get-CaasAclRules; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Name <string>
~~~~~~~~~

ACL name to filter

.. code-block:: powershell

    Position?                    0
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to show the ACL rules from

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network.AclRuleType


NOTES
-----



EXAMPLES
---------

