Add-CaasServerDisk
===================

Synopsis
--------


Add-CaasServerDisk -SizeInGB <int> -Server <ServerType> [-SpeedId <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Add-CaasServerDisk -SizeInGB <int> -Server <ServerType> [-Speed <DiskSpeedType>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Add-CaasServerDisk -SizeInGB <int> -Server <ServerType> [-ScsiId <int>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                                                                                                                

----------                                                                                                                                                                                                                                                                                                                                

{@{name=Add-CaasServerDisk; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Add-CaasServerDisk; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Add-CaasServerDisk; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-PassThru <switch>
~~~~~~~~~

Return the Server object after execution

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ScsiId <int>
~~~~~~~~~

The Scsi Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           ScsiId
Aliases                      None
Dynamic?                     false

 
-Server <ServerType>
~~~~~~~~~

The server to action on

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-SizeInGB <int>
~~~~~~~~~

The new disk size

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Speed <DiskSpeedType>
~~~~~~~~~

The disk speed to be created

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           DiskSpeedType
Aliases                      None
Dynamic?                     false

 
-SpeedId <string>
~~~~~~~~~

The speedId of the new disk. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           SpeedId
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

