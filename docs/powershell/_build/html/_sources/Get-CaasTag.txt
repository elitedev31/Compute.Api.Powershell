Get-CaasTag
===================

Synopsis
--------


Get-CaasTag [-AssetId <string>] [-AssetType <AssetType>] [-DataCenterId <string>] [-TagKeyName <string>] [-TagKeyId <guid>] [-Value <string>] [-ValueRequired <bool>] [-DisplayOnReport <bool>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                             

----------                                                                                             

{@{name=Get-CaasTag; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-AssetId <string>
~~~~~~~~~

The asset id to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue, ByPropertyName)
Parameter set name           Filtered
Aliases                      Id
Dynamic?                     false

 
-AssetType <AssetType>
~~~~~~~~~

The asset type to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
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
Parameter set name           Filtered
Aliases                      Location
Dynamic?                     false

 
-DisplayOnReport <bool>
~~~~~~~~~

The display on report

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
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

 
-TagKeyId <guid>
~~~~~~~~~

The tag key id to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-TagKeyName <string>
~~~~~~~~~

The tag key name to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-Value <string>
~~~~~~~~~

The value to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-ValueRequired <bool>
~~~~~~~~~

The value is required

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false


INPUTS
------

System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

