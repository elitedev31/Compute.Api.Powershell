Get-CaasOperatingSystem
===================

Synopsis
--------


Get-CaasOperatingSystem -DataCenterId <string> [-Name <string>] [-OperatingSystemId <string>] [-OperatingSystemFamily <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                         

----------                                                                                                         

{@{name=Get-CaasOperatingSystem; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

The Data center Id/location for figuring out the operating systems supported

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Name <string>
~~~~~~~~~

The Os image name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-OperatingSystemFamily <string>
~~~~~~~~~

The Os family like : Unix

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-OperatingSystemId <string>
~~~~~~~~~

The Os id, eg : CENTOS5/32

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
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


INPUTS
------

System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.OperatingSystemType


NOTES
-----



EXAMPLES
---------

