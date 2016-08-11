New-CaasUploadCustomerImage
===================

Synopsis
--------


New-CaasUploadCustomerImage -Ovf <string> -VirtualImage <string> [-Manifest <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasUploadCustomerImage -VirtualAppliance <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                    

----------                                                                                                                                                                                                                                    

{@{name=New-CaasUploadCustomerImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasUploadCustomerImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Manifest <string>
~~~~~~~~~

The path to the manifest file

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           IndividualFiles
Aliases                      None
Dynamic?                     false

 
-Ovf <string>
~~~~~~~~~

The path to the OVF file.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           IndividualFiles
Aliases                      None
Dynamic?                     false

 
-VirtualAppliance <string>
~~~~~~~~~

The path to an OVA (Virtual Appliance) file.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Appliance
Aliases                      None
Dynamic?                     false

 
-VirtualImage <string>
~~~~~~~~~

The path to the virtual image (e.g. VMDK, VHD) file.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           IndividualFiles
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Server.ServerImageWithStateType


NOTES
-----



EXAMPLES
---------

