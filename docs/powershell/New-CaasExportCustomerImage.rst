
New-CaasExportCustomerImage
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasExportCustomerImage -CustomerImage <ImagesWithDiskSpeedImage> -OvfPrefix <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-CustomerImage <ImagesWithDiskSpeedImage>
~~~~~~~~~

The Customer Image.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-OvfPrefix <string>
~~~~~~~~~

A prefix for this export. Must not contain spaces.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Image.ImageExportType


Notes
-----



Examples
---------


