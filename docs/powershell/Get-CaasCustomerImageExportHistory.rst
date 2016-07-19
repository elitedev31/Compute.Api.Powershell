
Get-CaasCustomerImageExportHistory
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasCustomerImageExportHistory [-RecordsToReturn <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-RecordsToReturn <int>
~~~~~~~~~

Number of records to return, max 100.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Image.ImageExportRecord


Notes
-----



Examples
---------


