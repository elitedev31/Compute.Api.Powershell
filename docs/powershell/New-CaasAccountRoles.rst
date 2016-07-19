
New-CaasAccountRoles
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasAccountRoles [-Network <bool>] [-Server <bool>] [-Backup <bool>] [-CreateImage <bool>] [-Storage <bool>] [-Reports <bool>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasAccountRoles [-ReadOnly <bool>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Backup <bool>
~~~~~~~~~

True of False for backup role

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           SubAdministrator     Aliases                      None     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-CreateImage <bool>
~~~~~~~~~

True of False for create image role

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           SubAdministrator     Aliases                      None     Dynamic?                     false





-Network <bool>
~~~~~~~~~

True of False for network role

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           SubAdministrator     Aliases                      None     Dynamic?                     false





-ReadOnly <bool>
~~~~~~~~~

True of False for reports role

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           ReadOnly     Aliases                      None     Dynamic?                     false





-Reports <bool>
~~~~~~~~~

True of False for reports role

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           SubAdministrator     Aliases                      None     Dynamic?                     false





-Server <bool>
~~~~~~~~~

True of False for server role

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           SubAdministrator     Aliases                      None     Dynamic?                     false





-Storage <bool>
~~~~~~~~~

True of False for storage role

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           SubAdministrator     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Directory.Role[]


Notes
-----



Examples
---------


