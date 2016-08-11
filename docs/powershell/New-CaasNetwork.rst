
New-CaasNetwork
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasNetwork -Name <string> [-Datacentre <DatacenterWithMaintenanceStatusType>] [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasNetwork -Name <string> [-Location <string>] [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Datacentre <DatacenterWithMaintenanceStatusType>
~~~~~~~~~

The data centre location where the network will be deployed.

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           DataCentre
* Aliases                      None
* Dynamic?                     false





-Description <string>
~~~~~~~~~

The description of the network

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Location <string>
~~~~~~~~~

The data centre location where the network will be deployed.

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           Location
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

A unique name for the new network to deploy

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Datacenter.DatacenterWithMaintenanceStatusType
System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


