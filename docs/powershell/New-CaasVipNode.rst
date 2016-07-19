
New-CaasVipNode
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasVipNode -NetworkDomain <NetworkDomainType> -NodeName <string> -IPType <IpItemChoiceType> -IPAddress <string> -Enabled <bool> -ConnectionLimit <int> -ConnectionRateLimit <int> [-Description <string>] [-HealthMonitorId <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-IPAddress <string>
~~~~~~~~~

The VIP Node IP Address

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-IPType <IpItemChoiceType>
~~~~~~~~~

The VIP Node IP Type

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-NodeName <string>
~~~~~~~~~

The VIP Node name

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





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


