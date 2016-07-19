
Set-CaasBackupClient
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasBackupClient -Server <ServerType> -BackupClient <BackupClientDetailsType> -StoragePolicy <BackupStoragePolicy> -SchedulePolicy <BackupSchedulePolicy> [-Aletring <AlertingType>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Aletring <AlertingType>
~~~~~~~~~

The alerting type to modify

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-BackupClient <BackupClientDetailsType>
~~~~~~~~~

The backup client details to modify

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-SchedulePolicy <BackupSchedulePolicy>
~~~~~~~~~

The schedule policy to modify

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

The server to modify the backup client

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-StoragePolicy <BackupStoragePolicy>
~~~~~~~~~

The storage policy to modify

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ServerType


Notes
-----



Examples
---------


