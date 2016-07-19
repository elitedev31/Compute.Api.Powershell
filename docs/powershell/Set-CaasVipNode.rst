
Set-CaasVipNode
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasVipNode -Node <NodeType> [-Description <string>] [-Enabled <bool>] [-HealthMonitorId <string>] [-ConnectionLimit <int>] [-ConnectionRateLimit <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ConnectionLimit <int>
~~~~~~~~~

The VIP Node Connection Limit

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ConnectionRateLimit <int>
~~~~~~~~~

The VIP Node Connection Rate Limit

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Description <string>
~~~~~~~~~

The Node description

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Enabled <bool>
~~~~~~~~~

The VIP Node Status

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-HealthMonitorId <string>
~~~~~~~~~

The VIP Node Health Monitor Id

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Node <NodeType>
~~~~~~~~~

The VIP Node

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.NodeType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


