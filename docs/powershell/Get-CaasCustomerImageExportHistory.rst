Get-CaasCustomerImageExportHistory
===================

Synopsis
--------


Get-CaasCustomerImageExportHistory [-RecordsToReturn <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                    

----------                                                                                                                    

{@{name=Get-CaasCustomerImageExportHistory; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-RecordsToReturn &lt;int&gt;
~~~~~~~~~

Number of records to return, max 100.

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

DD.CBU.Compute.Api.Contracts.Image.ImageExportRecord


NOTES
-----



EXAMPLES
---------

