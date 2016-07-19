
New-CaasVIPVirtualListener
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasVIPVirtualListener -NetworkDomain <NetworkDomainType> -Name <string> -Type <string> -Protocol <string> -ConnectionLimit <int> -ConnectionRateLimit <int> -SourcePortPreservation <string> [-Description <string>] [-IPAddress <string>] [-Port <int>] [-Enabled <bool>] [-PoolId <string>] [-ClientClonePoolId <string>] [-PersistenceProfileId <string>] [-FallbackPersistenceProfileId <string>] [-OptimizationProfileId <string>] [-iRuleId <string[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-ClientClonePoolId <string>
~~~~~~~~~

The VIP virtual listener Client Clone Pool Id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ConnectionLimit <int>
~~~~~~~~~

The VIP virtual listener Connection Limit

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ConnectionRateLimit <int>
~~~~~~~~~

The VIP virtual listener Connection Rate Limit

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Description <string>
~~~~~~~~~

The virtual listener description

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Enabled <bool>
~~~~~~~~~

The VIP virtual listener Status

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-FallbackPersistenceProfileId <string>
~~~~~~~~~

The VIP virtual listener Fallback Persistence Profile Id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-IPAddress <string>
~~~~~~~~~

The VIP virtual listener IP Address

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

The virtual listener name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-OptimizationProfileId <string>
~~~~~~~~~

The VIP virtual listener Optimization Profile Id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PersistenceProfileId <string>
~~~~~~~~~

The VIP virtual listener Persistence Profile Id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PoolId <string>
~~~~~~~~~

The VIP virtual listener Pool Id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Port <int>
~~~~~~~~~

The VIP virtual listener Port

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Protocol <string>
~~~~~~~~~

The VIP virtual listener Protocol

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-SourcePortPreservation <string>
~~~~~~~~~

The VIP virtual listener Source Port Preservation

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Type <string>
~~~~~~~~~

The VIP virtual listener IP Type

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-iRuleId <string[]>
~~~~~~~~~

The VIP virtual listener iRule Ids

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


