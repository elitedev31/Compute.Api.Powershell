
Update-CaasCustomerImageMetadata
===================

Synopsis
--------

.. code-block:: powershell
    
    
Update-CaasCustomerImageMetadata -CustomerImage <CustomerImageType> [-Description <string>] [-CpuSpeed <string>] [-OperatingSystemId <string>] [-DiskSpeeds <ImageMetadataTypeDisk[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Update-CaasCustomerImageMetadata -ImageId <guid> [-Description <string>] [-CpuSpeed <string>] [-OperatingSystemId <string>] [-DiskSpeeds <ImageMetadataTypeDisk[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-CpuSpeed <string>
~~~~~~~~~

The cpu speed of the customer image

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-CustomerImage <CustomerImageType>
~~~~~~~~~

The customer image

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           CustomerImage     Aliases                      None     Dynamic?                     false





-Description <string>
~~~~~~~~~

The description of the customer image

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-DiskSpeeds <ImageMetadataTypeDisk[]>
~~~~~~~~~

The disk details of the customer image

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ImageId <guid>
~~~~~~~~~

The id of the customer image

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           CustomerImageId     Aliases                      None     Dynamic?                     false





-OperatingSystemId <string>
~~~~~~~~~

The id of the operating system

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.CustomerImageType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


