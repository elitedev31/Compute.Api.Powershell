
Get-CaasPortList
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasPortList -NetworkDomainId <guid> [-PortListId <guid>] [-Name <string>] [-State <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-Name <string>
~~~~~~~~~

The Port List name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Filtered
* Aliases                      None
* Dynamic?                     false





-NetworkDomainId <guid>
~~~~~~~~~

The network domain id

* Position?                    Named
* Accept pipeline input?       true (ByValue, ByPropertyName)
* Parameter set name           Filtered
* Aliases                      id
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





-PortListId <guid>
~~~~~~~~~

The Port list id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Filtered
* Aliases                      None
* Dynamic?                     false





-State <string>
~~~~~~~~~

The State of the Port List

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Filtered
* Aliases                      None
* Dynamic?                     false





Inputs
------

System.Guid
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.PortListType


Notes
-----



Examples
---------


