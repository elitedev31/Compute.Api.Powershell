Get-CaasCustomerImage
===================

Synopsis
--------


Get-CaasCustomerImage [-Network <NetworkWithLocationsNetwork>] [-Name <string>] [-DataCenterId <string>] [-ImageId <guid>] [-OperatingSystemId <string>] [-OperatingSystemFamily <string>] [-Mcp1] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                       

----------                                                                                                       

{@{name=Get-CaasCustomerImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-DataCenterId <string>
~~~~~~~~~

Data Center Id/ Location to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      Location
Dynamic?                     false

 
-ImageId <guid>
~~~~~~~~~

ImageId to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Mcp1 <switch>
~~~~~~~~~

Explicitly calling MCP 1.0 Api

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP10
Aliases                      None
Dynamic?                     false

 
-Name <string>
~~~~~~~~~

Name of the Image to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

Operating System family to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP10
Aliases                      None
Dynamic?                     false

 
-OperatingSystemFamily <string>
~~~~~~~~~

Operating System family to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-OperatingSystemId <string>
~~~~~~~~~

Operating System Id to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-OrderBy <string>
~~~~~~~~~

The Order By of the results, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PageNumber <int>
~~~~~~~~~

The Page Number of the result page, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PageSize <int>
~~~~~~~~~

The Page Size of the result page, only supported for MCP2

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

DD.CBU.Compute.Api.Contracts.Network20.CustomerImageType
DD.CBU.Compute.Api.Contracts.Image.ImagesWithDiskSpeedImage


NOTES
-----



EXAMPLES
---------

