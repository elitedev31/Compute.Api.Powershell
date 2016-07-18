Get-CaasBackupStoragePolicies
===================

Synopsis
--------


Get-CaasBackupStoragePolicies -Server <ServerType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                               

----------                                                                                                               

{@{name=Get-CaasBackupStoragePolicies; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Server &lt;ServerType&gt;
~~~~~~~~~

The server associated with the backup storage policies

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Backup.BackupStoragePolicy


NOTES
-----



EXAMPLES
---------

