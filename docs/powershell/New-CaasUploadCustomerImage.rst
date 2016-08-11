
New-CaasUploadCustomerImage
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasUploadCustomerImage -Ovf <string> -VirtualImage <string> [-Manifest <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasUploadCustomerImage -VirtualAppliance <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-Manifest <string>
~~~~~~~~~

The path to the manifest file

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           IndividualFiles
* Aliases                      None
* Dynamic?                     false





-Ovf <string>
~~~~~~~~~

The path to the OVF file.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           IndividualFiles
* Aliases                      None
* Dynamic?                     false





-VirtualAppliance <string>
~~~~~~~~~

The path to an OVA (Virtual Appliance) file.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Appliance
* Aliases                      None
* Dynamic?                     false





-VirtualImage <string>
~~~~~~~~~

The path to the virtual image (e.g. VMDK, VHD) file.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           IndividualFiles
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


