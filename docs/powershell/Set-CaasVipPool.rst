
Set-CaasVipPool
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasVipPool -VipPool <PoolType> [-Description <string>] [-LoadBalanceMethod <string>] [-HealthMonitorId <string[]>] [-ServiceDownAction <string>] [-SlowRampTime <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Description <string>
~~~~~~~~~

The VIP Pool description

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-HealthMonitorId <string[]>
~~~~~~~~~

The VIP Pool Health Monitor Ids

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-LoadBalanceMethod <string>
~~~~~~~~~

The VIP Pool Load balance method

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ServiceDownAction <string>
~~~~~~~~~

The VIP Pool Service down action

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-SlowRampTime <int>
~~~~~~~~~

The VIP Pool Slow ramp time

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-VipPool <PoolType>
~~~~~~~~~

The Firewall Rule

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.PoolType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


