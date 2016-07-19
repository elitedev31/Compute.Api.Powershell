
Set-CaasServerDiskSpeed
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasServerDiskSpeed -ScsiId <int> -Server <ServerType> [-SpeedId <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Set-CaasServerDiskSpeed -ScsiId <int> -Server <ServerType> [-Speed <DiskSpeedType>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PassThru <switch>
~~~~~~~~~

Return the Server object after execution

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ScsiId <int>
~~~~~~~~~

SCSI Id of the disk to be resized

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

The server to action on

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Speed <DiskSpeedType>
~~~~~~~~~

The disk speed

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           DiskSpeedType
* Aliases                      None
* Dynamic?                     false





-SpeedId <string>
~~~~~~~~~

The speedId of the new disk. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           SpeedId
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


