
Set-CaasProvisionBackup
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasProvisionBackup -Server <ServerType> -IsEnable <bool> [-BackupServicePlan <ServicePlan>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-BackupServicePlan <ServicePlan>
~~~~~~~~~

The service plan of the backup

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-IsEnable <bool>
~~~~~~~~~

Determines whether to enable or disable backup. If enable, you must use BackupServicePlan

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

The server to action on

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





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


