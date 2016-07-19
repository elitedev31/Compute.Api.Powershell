
Remove-CaasAclRule
===================

Synopsis
--------

.. code-block:: powershell
    
    
Remove-CaasAclRule -Network <NetworkWithLocationsNetwork> -AclRule <AclRuleType> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]





Description
-----------



Parameters
----------




-AclRule <AclRuleType>
~~~~~~~~~

The ACL rule to delete

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Confirm <switch>
~~~~~~~~~



* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      cf
* Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network that the ACL Rule exists

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-WhatIf <switch>
~~~~~~~~~



* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      wi
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Network.AclRuleType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


