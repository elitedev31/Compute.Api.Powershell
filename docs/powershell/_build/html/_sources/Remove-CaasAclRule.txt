Remove-CaasAclRule
===================

Synopsis
--------


Remove-CaasAclRule -Network <NetworkWithLocationsNetwork> -AclRule <AclRuleType> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                    

----------                                                                                                    

{@{name=Remove-CaasAclRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-AclRule <AclRuleType>
~~~~~~~~~

The ACL rule to delete

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Confirm <switch>
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      cf
Dynamic?                     false

 
-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network that the ACL Rule exists

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-WhatIf <switch>
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      wi
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Network.AclRuleType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

