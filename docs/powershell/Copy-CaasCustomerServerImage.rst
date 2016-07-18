Copy-CaasCustomerServerImage
===================

Synopsis
--------


Copy-CaasCustomerServerImage -SourceImage <ImagesWithDiskSpeedImage> -TargetImageName <string> -Network <NetworkWithLocationsNetwork> [-Description <string>] [-OvfPrefix <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                              

----------                                                                                                              

{@{name=Copy-CaasCustomerServerImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Description <string>
~~~~~~~~~

The target description

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The target data centre location for the customer image.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-OvfPrefix <string>
~~~~~~~~~

A prefix for this copy. Must not contain spaces.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-SourceImage <ImagesWithDiskSpeedImage>
~~~~~~~~~

The Source customer image.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-TargetImageName <string>
~~~~~~~~~

The Target image name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Image.ImageExportType


NOTES
-----



EXAMPLES
---------

