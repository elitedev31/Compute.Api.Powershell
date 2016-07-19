
Add-CaasBackupClient
===================

Synopsis
--------

.. code-block:: powershell
    
    
Add-CaasBackupClient -Server <ServerType> -StoragePolicy <BackupStoragePolicy> -SchedulePolicy <BackupSchedulePolicy> -ClientType <BackupClientType> [-Trigger <TriggerType>] [-EmailAddresses <IReadOnlyList[string]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-ClientType <BackupClientType>
~~~~~~~~~

The backup client type availabe from Get-CaasBackupClientTypes cmdlet

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-EmailAddresses <IReadOnlyList[string]>
~~~~~~~~~

The email addresses for alerting purposes. At least one must be added when using alerting

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-SchedulePolicy <BackupSchedulePolicy>
~~~~~~~~~

The schedule policy availabe from Get-CaasBackupSchedulePolicies cmdlet

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

The server to add the backup client

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-StoragePolicy <BackupStoragePolicy>
~~~~~~~~~

The storage policy availabe from Get-CaasBackupStoragePolicies cmdlet

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Trigger <TriggerType>
~~~~~~~~~

The trigger type for alerting purposes

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.String


Notes
-----



Examples
---------


