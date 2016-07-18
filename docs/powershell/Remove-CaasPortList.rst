Remove-CaasPortList
===================

Synopsis
--------


Remove-CaasPortList -Id <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                     

----------                                                                                                     

{@{name=Remove-CaasPortList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Id <string>
~~~~~~~~~

The id of Port List

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue, ByPropertyName)
Parameter set name           (All)
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

