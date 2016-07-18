Get-CaasPortList
===================

Synopsis
--------


Get-CaasPortList -NetworkDomainId <guid> [-PortListId <guid>] [-Name <string>] [-State <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                  

----------                                                                                                  

{@{name=Get-CaasPortList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Name &lt;string&gt;
~~~~~~~~~

The Port List name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-NetworkDomainId &lt;guid&gt;
~~~~~~~~~

The network domain id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue, ByPropertyName)
Parameter set name           Filtered
Aliases                      id
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

 
-PortListId &lt;guid&gt;
~~~~~~~~~

The Port list id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-State &lt;string&gt;
~~~~~~~~~

The State of the Port List

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

DD.CBU.Compute.Api.Contracts.Network20.PortListType


NOTES
-----



EXAMPLES
---------

