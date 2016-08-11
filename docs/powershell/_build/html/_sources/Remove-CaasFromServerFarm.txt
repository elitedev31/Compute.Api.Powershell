Remove-CaasFromServerFarm
===================

Synopsis
--------


Remove-CaasFromServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -RealServer <RealServer> [-RealServerPort <int>] [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]

Remove-CaasFromServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -Probe <Probe> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                

----------                                                                                                                                                                                                                                

{@{name=Remove-CaasFromServerFarm; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasFromServerFarm; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Probe <Probe>
~~~~~~~~~

The probe to be removed to the server farm

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Probe
Aliases                      None
Dynamic?                     false

 
-RealServer <RealServer>
~~~~~~~~~

The real server to be removed to the server farm

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           RealServer
Aliases                      None
Dynamic?                     false

 
-RealServerPort <int>
~~~~~~~~~

The real server port to be removed to the server farm

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           RealServer
Aliases                      None
Dynamic?                     false

 
-ServerFarm <ServerFarm>
~~~~~~~~~

The server farm that will get removed a probe or real server

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
DD.CBU.Compute.Api.Contracts.Vip.ServerFarm
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

