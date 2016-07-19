
New-CaasServer
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasServer -ServerDetails <CaasServerDetails> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PassThru <switch>
~~~~~~~~~

Return the Server object after execution

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ServerDetails <CaasServerDetails>
~~~~~~~~~

The server details created by New-CaasServerDetails

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.CaasServerDetails
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ServerType


Notes
-----



Examples
---------


