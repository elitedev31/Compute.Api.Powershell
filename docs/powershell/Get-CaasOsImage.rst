
Get-CaasOsImage
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasOsImage [-Network <NetworkWithLocationsNetwork>] [-Id <guid>] [-DataCenterId <string>] [-Name <string>] [-State <string>] [-OperatingSystemId <string>] [-OperatingSystemFamily <string>] [-Mcp1] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-DataCenterId <string>
~~~~~~~~~

The Data center Id

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      Location
* Dynamic?                     false





-Id <guid>
~~~~~~~~~

The Os Image Id

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      ImageId
* Dynamic?                     false





-Mcp1 <switch>
~~~~~~~~~

Explicitly calling MCP 1.0 Api

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP10
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

The Os image name

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to show the images from

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           MCP10
* Aliases                      None
* Dynamic?                     false





-OperatingSystemFamily <string>
~~~~~~~~~

The Os family like : Unix

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-OperatingSystemId <string>
~~~~~~~~~

The Os id

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-OrderBy <string>
~~~~~~~~~

The Order By of the results, only supported for MCP2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PageNumber <int>
~~~~~~~~~

The Page Number of the result page, only supported for MCP2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PageSize <int>
~~~~~~~~~

The Page Size of the result page, only supported for MCP2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-State <string>
~~~~~~~~~

The Os image State

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

System.Nullable`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.OsImageType
DD.CBU.Compute.Api.Contracts.Image.ImagesWithDiskSpeedImage


Notes
-----



Examples
---------


