Get-CaasTagKey
===================

Synopsis
--------


Get-CaasTagKey [-TagKeyId <guid>] [-Name <string>] [-ValueRequired <bool>] [-DisplayOnReport <bool>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                

----------                                                                                                

{@{name=Get-CaasTagKey; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-DisplayOnReport <bool>
~~~~~~~~~

The displayed on reports to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-Name <string>
~~~~~~~~~

The tag key name to filter

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
Accept pipeline input?       true (ByValue)
Parameter set name           Filtered
Aliases                      Id
Dynamic?                     false

 
-ValueRequired <bool>
~~~~~~~~~

The value required to filter

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false


INPUTS
------

System.Guid
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

