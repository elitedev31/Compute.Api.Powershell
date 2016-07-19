
New-CaasBackupRestoreJob
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasBackupRestoreJob -Server <ServerType> -BackupClient <BackupClientDetailsType> -AsAtDate <datetime> [-TargetServer <ServerType>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasBackupRestoreJob -ServerId <guid> -BackupClientId <guid> -AsAtDate <datetime> [-TargetServerId <guid>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-AsAtDate <datetime>
~~~~~~~~~

The date to restore to.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-BackupClient <BackupClientDetailsType>
~~~~~~~~~

The backup client to restore, must be a file system client

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           restoreByObject
* Aliases                      None
* Dynamic?                     false





-BackupClientId <guid>
~~~~~~~~~

The backup client Id to restore, must be a file system client

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           restoreById
* Aliases                      None
* Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

The server to restore

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           restoreByObject
* Aliases                      None
* Dynamic?                     false





-ServerId <guid>
~~~~~~~~~

The ID of the server to restore

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           restoreById
* Aliases                      None
* Dynamic?                     false





-TargetServer <ServerType>
~~~~~~~~~

The target server to restore onto if out of place restore

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           restoreByObject
* Aliases                      None
* Dynamic?                     false





-TargetServerId <guid>
~~~~~~~~~

The ID of the target server to restore onto if out of place restore.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           restoreById
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.General.Status


Notes
-----



Examples
---------


