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

-Connection &lt;ComputeServiceConnection&gt;
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PassThru &lt;switch&gt;
~~~~~~~~~

Return the Server object after execution

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ScsiId &lt;int&gt;
~~~~~~~~~

The Scsi Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           ScsiId
Aliases                      None
Dynamic?                     false

 
-Server &lt;ServerType&gt;
~~~~~~~~~

The server to action on

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-SizeInGB &lt;int&gt;
~~~~~~~~~

The new disk size

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Speed &lt;DiskSpeedType&gt;
~~~~~~~~~

The disk speed to be created

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           DiskSpeedType
Aliases                      None
Dynamic?                     false

 
-SpeedId &lt;string&gt;
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

