New-CaasNetwork
===================

Synopsis
--------


New-CaasNetwork -Name <string> [-Datacentre <DatacenterWithMaintenanceStatusType>] [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasNetwork -Name <string> [-Location <string>] [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                            

----------                                                                                                                                                                                                            

{@{name=New-CaasNetwork; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasNetwork; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Datacentre <DatacenterWithMaintenanceStatusType>
~~~~~~~~~

The data centre location where the network will be deployed.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           DataCentre
Aliases                      None
Dynamic?                     false

 
-Description <string>
~~~~~~~~~

The description of the network

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Location <string>
~~~~~~~~~

The data centre location where the network will be deployed.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           Location
Aliases                      None
Dynamic?                     false

 
-Name <string>
~~~~~~~~~

A unique name for the new network to deploy

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Datacenter.DatacenterWithMaintenanceStatusType
System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

