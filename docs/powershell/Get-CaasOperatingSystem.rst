
Get-CaasOperatingSystem
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasOperatingSystem -DataCenterId <string> [-Name <string>] [-OperatingSystemId <string>] [-OperatingSystemFamily <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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

The Data center Id/location for figuring out the operating systems supported

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

The Os image name

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           Filtered
* Aliases                      None
* Dynamic?                     false





-OperatingSystemFamily <string>
~~~~~~~~~

The Os family like : Unix

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           Filtered
* Aliases                      None
* Dynamic?                     false





-OperatingSystemId <string>
~~~~~~~~~

The Os id, eg : CENTOS5/32

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           Filtered
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





Inputs
------

System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.OperatingSystemType


Notes
-----



Examples
---------


