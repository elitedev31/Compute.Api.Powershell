
Copy-CaasCustomerServerImage
===================

Synopsis
--------

.. code-block:: powershell
    
    
Copy-CaasCustomerServerImage -SourceImage <ImagesWithDiskSpeedImage> -TargetImageName <string> -Network <NetworkWithLocationsNetwork> [-Description <string>] [-OvfPrefix <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Description <string>
~~~~~~~~~

The target description

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The target data centre location for the customer image.

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-OvfPrefix <string>
~~~~~~~~~

A prefix for this copy. Must not contain spaces.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-SourceImage <ImagesWithDiskSpeedImage>
~~~~~~~~~

The Source customer image.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-TargetImageName <string>
~~~~~~~~~

The Target image name

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Image.ImageExportType


Notes
-----



Examples
---------


