Add-CaasToServerFarm
===================

Synopsis
--------


Add-CaasToServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -RealServer <RealServer> [-RealServerPort <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Add-CaasToServerFarm -Network <NetworkWithLocationsNetwork> -ServerFarm <ServerFarm> -Probe <Probe> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                      

----------                                                                                                                                                                                                                      

{@{name=Add-CaasToServerFarm; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Add-CaasToServerFarm; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

The probe to be added to the server farm

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Probe
Aliases                      None
Dynamic?                     false

 
-RealServer <RealServer>
~~~~~~~~~

The real server to be added to the server farm

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           RealServer
Aliases                      None
Dynamic?                     false

 
-RealServerPort <int>
~~~~~~~~~

The real server port to be added to the server farm

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           RealServer
Aliases                      None
Dynamic?                     false

 
-ServerFarm <ServerFarm>
~~~~~~~~~

The server farm that will get added a probe or real server

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
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

