
Set-CaasVIPVirtualListener
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasVIPVirtualListener -VirtualListener <VirtualListenerType> -ConnectionLimit <int> -ConnectionRateLimit <int> [-Description <string>] [-Enabled <bool>] [-SourcePortPreservation <string>] [-PoolId <guid>] [-ClientClonePoolId <guid>] [-PersistenceProfileId <string>] [-FallbackPersistenceProfileId <string>] [-OptimizationProfileId <string>] [-iRuleId <string[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-ClientClonePoolId <guid>
~~~~~~~~~

The VIP virtual listener Client Clone Pool Id

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ConnectionLimit <int>
~~~~~~~~~

The VIP virtual listener Connection Limit

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ConnectionRateLimit <int>
~~~~~~~~~

The VIP virtual listener Connection Rate Limit

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Description <string>
~~~~~~~~~

The virtual listener description

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Enabled <bool>
~~~~~~~~~

The VIP virtual listener Status

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-FallbackPersistenceProfileId <string>
~~~~~~~~~

The VIP virtual listener Fallback Persistence Profile Id

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-OptimizationProfileId <string>
~~~~~~~~~

The VIP virtual listener Optimization Profile Id

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PersistenceProfileId <string>
~~~~~~~~~

The VIP virtual listener Persistence Profile Id

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PoolId <guid>
~~~~~~~~~

The VIP virtual listener Pool Id

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-SourcePortPreservation <string>
~~~~~~~~~

The VIP virtual listener Source Port Preservation

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-VirtualListener <VirtualListenerType>
~~~~~~~~~

The virtual listener

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-iRuleId <string[]>
~~~~~~~~~

The VIP virtual listener iRule Ids

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.VirtualListenerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


