New-CaasBackupRestoreJob
===================

Synopsis
--------


New-CaasBackupRestoreJob -Server <ServerType> -BackupClient <BackupClientDetailsType> -AsAtDate <datetime> [-TargetServer <ServerType>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasBackupRestoreJob -ServerId <guid> -BackupClientId <guid> -AsAtDate <datetime> [-TargetServerId <guid>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                              

----------                                                                                                                                                                                                                              

{@{name=New-CaasBackupRestoreJob; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasBackupRestoreJob; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-AsAtDate &lt;datetime&gt;
~~~~~~~~~

The date to restore to.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-BackupClient &lt;BackupClientDetailsType&gt;
~~~~~~~~~

The backup client to restore, must be a file system client

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           restoreByObject
Aliases                      None
Dynamic?                     false

 
-BackupClientId &lt;guid&gt;
~~~~~~~~~

The backup client Id to restore, must be a file system client

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           restoreById
Aliases                      None
Dynamic?                     false

 
-Connection &lt;ComputeServiceConnection&gt;
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Server &lt;ServerType&gt;
~~~~~~~~~

The server to restore

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           restoreByObject
Aliases                      None
Dynamic?                     false

 
-ServerId &lt;guid&gt;
~~~~~~~~~

The ID of the server to restore

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           restoreById
Aliases                      None
Dynamic?                     false

 
-TargetServer &lt;ServerType&gt;
~~~~~~~~~

The target server to restore onto if out of place restore

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           restoreByObject
Aliases                      None
Dynamic?                     false

 
-TargetServerId &lt;guid&gt;
~~~~~~~~~

The ID of the target server to restore onto if out of place restore.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           restoreById
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.General.Status


NOTES
-----



EXAMPLES
---------

