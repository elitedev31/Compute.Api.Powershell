Get-CaasServerMonitoringUsageReport
===================

Synopsis
--------


Get-CaasServerMonitoringUsageReport -StartDate <datetime> [-EndDate <datetime>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                     

----------                                                                                                                     

{@{name=Get-CaasServerMonitoringUsageReport; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-EndDate <datetime>
~~~~~~~~~

The end date

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-StartDate <datetime>
~~~~~~~~~

The start date

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

System.DateTime
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.String


NOTES
-----



EXAMPLES
---------

