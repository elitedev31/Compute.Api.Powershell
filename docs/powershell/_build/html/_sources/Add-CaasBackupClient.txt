Add-CaasBackupClient
===================

Synopsis
--------


Add-CaasBackupClient -Server <ServerType> -StoragePolicy <BackupStoragePolicy> -SchedulePolicy <BackupSchedulePolicy> -ClientType <BackupClientType> [-Trigger <TriggerType>] [-EmailAddresses <IReadOnlyList[string]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                      

----------                                                                                                      

{@{name=Add-CaasBackupClient; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-ClientType <BackupClientType>
~~~~~~~~~

The backup client type availabe from Get-CaasBackupClientTypes cmdlet

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
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

 
-EmailAddresses <IReadOnlyList[string]>
~~~~~~~~~

The email addresses for alerting purposes. At least one must be added when using alerting

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-SchedulePolicy <BackupSchedulePolicy>
~~~~~~~~~

The schedule policy availabe from Get-CaasBackupSchedulePolicies cmdlet

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Server <ServerType>
~~~~~~~~~

The server to add the backup client

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-StoragePolicy <BackupStoragePolicy>
~~~~~~~~~

The storage policy availabe from Get-CaasBackupStoragePolicies cmdlet

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Trigger <TriggerType>
~~~~~~~~~

The trigger type for alerting purposes

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.String


NOTES
-----



EXAMPLES
---------

