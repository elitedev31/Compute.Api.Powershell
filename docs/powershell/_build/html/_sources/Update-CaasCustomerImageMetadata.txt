Update-CaasCustomerImageMetadata
===================

Synopsis
--------


Update-CaasCustomerImageMetadata -CustomerImage <CustomerImageType> [-Description <string>] [-CpuSpeed <string>] [-OperatingSystemId <string>] [-DiskSpeeds <ImageMetadataTypeDisk[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Update-CaasCustomerImageMetadata -ImageId <guid> [-Description <string>] [-CpuSpeed <string>] [-OperatingSystemId <string>] [-DiskSpeeds <ImageMetadataTypeDisk[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                              

----------                                                                                                                                                                                                                                              

{@{name=Update-CaasCustomerImageMetadata; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Update-CaasCustomerImageMetadata; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-CpuSpeed <string>
~~~~~~~~~

The cpu speed of the customer image

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-CustomerImage <CustomerImageType>
~~~~~~~~~

The customer image

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           CustomerImage
Aliases                      None
Dynamic?                     false

 
-Description <string>
~~~~~~~~~

The description of the customer image

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-DiskSpeeds <ImageMetadataTypeDisk[]>
~~~~~~~~~

The disk details of the customer image

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ImageId <guid>
~~~~~~~~~

The id of the customer image

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           CustomerImageId
Aliases                      None
Dynamic?                     false

 
-OperatingSystemId <string>
~~~~~~~~~

The id of the operating system

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.CustomerImageType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

