
Remove-CaasBackupJob
===================

Synopsis
--------

.. code-block:: powershell
    
    
Remove-CaasBackupJob -Server <ServerType> -BackupClient <BackupClientDetailsType> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]





Description
-----------



Parameters
----------




-BackupClient <BackupClientDetailsType>
~~~~~~~~~

The backup client details to modify

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Confirm <switch>
~~~~~~~~~



*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      cf     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

The server to modify the backup client

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-WhatIf <switch>
~~~~~~~~~



*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      wi     Dynamic?                     false





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


