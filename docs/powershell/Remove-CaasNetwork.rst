
Remove-CaasNetwork
===================

Synopsis
--------

.. code-block:: powershell
    
    
Remove-CaasNetwork -Network <NetworkWithLocationsNetwork> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]





Description
-----------



Parameters
----------




-Confirm <switch>
~~~~~~~~~



*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      cf     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The target data centre location for the customer image.

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-WhatIf <switch>
~~~~~~~~~



*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      wi     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


