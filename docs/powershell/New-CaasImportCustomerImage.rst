
New-CaasImportCustomerImage
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasImportCustomerImage -CustomerImageName <string> -OvfPackage <OvfPackageType> -Network <NetworkWithLocationsNetwork> [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-CustomerImageName <string>
~~~~~~~~~

The Customer Image name.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Description <string>
~~~~~~~~~

The description

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The target data centre location for the customer image.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-OvfPackage <OvfPackageType>
~~~~~~~~~

An OVF Package on the organization’s FTPS account

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

DD.CBU.Compute.Api.Contracts.Server.ServerImageWithStateType


Notes
-----



Examples
---------


