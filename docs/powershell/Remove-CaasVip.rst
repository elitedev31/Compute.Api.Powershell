Remove-CaasVip
===================

Synopsis
--------


Remove-CaasVip -Network <NetworkWithLocationsNetwork> -Vip <Vip> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                

----------                                                                                                

{@{name=Remove-CaasVip; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

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

The network to manage the VIP settings

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Vip <Vip>
~~~~~~~~~

The vip to be deleted

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
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
DD.CBU.Compute.Api.Contracts.Vip.Vip
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

