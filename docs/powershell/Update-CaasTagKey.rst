
Update-CaasTagKey
===================

Synopsis
--------

.. code-block:: powershell
    
    
Update-CaasTagKey -Id <string> [-Name <string>] [-Description <string>] [-ValueRequired <bool>] [-DisplayOnReport <bool>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Description <string>
~~~~~~~~~

The description of tag key

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-DisplayOnReport <bool>
~~~~~~~~~

Whether the Tag Key will be displayed on reports

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Id <string>
~~~~~~~~~

The id of tag key

*     Position?                    Named     Accept pipeline input?       true (ByValue, ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Name <string>
~~~~~~~~~

The name of tag key

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ValueRequired <bool>
~~~~~~~~~

Whether value can be considered optional when the Tag Key is applied to a Cloud asset

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


