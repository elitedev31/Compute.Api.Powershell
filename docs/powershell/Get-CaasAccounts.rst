
Get-CaasAccounts
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasAccounts [[-UserName] <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-UserName <string>
~~~~~~~~~

Username to filter

* Position?                    1
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Directory.AccountWithPhoneNumber


Notes
-----



Examples
---------


