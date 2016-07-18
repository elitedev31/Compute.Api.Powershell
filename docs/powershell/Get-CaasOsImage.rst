Get-CaasOsImage
===================

Synopsis
--------


Get-CaasOsImage [-Network <NetworkWithLocationsNetwork>] [-Id <guid>] [-DataCenterId <string>] [-Name <string>] [-State <string>] [-OperatingSystemId <string>] [-OperatingSystemFamily <string>] [-Mcp1] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                 

----------                                                                                                 

{@{name=Get-CaasOsImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-Connection &lt;ComputeServiceConnection&gt;
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-DataCenterId &lt;string&gt;
~~~~~~~~~

The Data center Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      Location
Dynamic?                     false

 
-Id &lt;guid&gt;
~~~~~~~~~

The Os Image Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      ImageId
Dynamic?                     false

 
-Mcp1 &lt;switch&gt;
~~~~~~~~~

Explicitly calling MCP 1.0 Api

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP10
Aliases                      None
Dynamic?                     false

 
-Name &lt;string&gt;
~~~~~~~~~

The Os image name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network &lt;NetworkWithLocationsNetwork&gt;
~~~~~~~~~

The network to show the images from

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP10
Aliases                      None
Dynamic?                     false

 
-OperatingSystemFamily &lt;string&gt;
~~~~~~~~~

The Os family like : Unix

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-OperatingSystemId &lt;string&gt;
~~~~~~~~~

The Os id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-OrderBy &lt;string&gt;
~~~~~~~~~

The Order By of the results, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PageNumber &lt;int&gt;
~~~~~~~~~

The Page Number of the result page, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PageSize &lt;int&gt;
~~~~~~~~~

The Page Size of the result page, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-State &lt;string&gt;
~~~~~~~~~

The Os image State

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

System.Nullable`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.DatacenterType
DD.CBU.Compute.Api.Contracts.Image.ImagesWithDiskSpeedImage


NOTES
-----



EXAMPLES
---------

