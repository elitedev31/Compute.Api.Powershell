
Remove-CaasCustomerImage
===================

Synopsis
--------

.. code-block:: powershell
    
    
Remove-CaasCustomerImage -ServerImage <ImagesWithDiskSpeedImage> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]





Description
-----------



Parameters
----------




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





-ServerImage <ImagesWithDiskSpeedImage>
~~~~~~~~~

The server image retrieved by Get-CaasCustomerImages

* Position?                    Named
* Accept pipeline input?       true (ByValue)
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

DD.CBU.Compute.Api.Contracts.Image.ImagesWithDiskSpeedImage
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


