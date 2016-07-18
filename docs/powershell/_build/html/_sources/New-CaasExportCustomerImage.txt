New-CaasExportCustomerImage
===================

Synopsis
--------


New-CaasExportCustomerImage -CustomerImage <ImagesWithDiskSpeedImage> -OvfPrefix <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                             

----------                                                                                                             

{@{name=New-CaasExportCustomerImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-CustomerImage <ImagesWithDiskSpeedImage>
~~~~~~~~~

The Customer Image.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-OvfPrefix <string>
~~~~~~~~~

A prefix for this export. Must not contain spaces.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Image.ImageExportType


NOTES
-----



EXAMPLES
---------

