Remove-CaasBackupClient
===================

Synopsis
--------


Remove-CaasBackupClient -Server <ServerType> -BackupClient <BackupClientDetailsType> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                         

----------                                                                                                         

{@{name=Remove-CaasBackupClient; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-BackupClient <BackupClientDetailsType>
~~~~~~~~~

The backup client details to remove

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Confirm <switch>
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      cf
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

 
-Server <ServerType>
~~~~~~~~~

The server to remove the backup client from

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-WhatIf <switch>
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      wi
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

