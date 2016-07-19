
Get-CaasVipPool
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasVipPool [-Name <string>] [-NetworkDomain <NetworkDomainType>] [-PoolId <guid>] [-State <string>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Name <string>
~~~~~~~~~

The VIP Pool name

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           Filtered     Aliases                      None     Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           Filtered     Aliases                      None     Dynamic?                     false





-OrderBy <string>
~~~~~~~~~

The Order By of the results, only supported for MCP2

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PageNumber <int>
~~~~~~~~~

The Page Number of the result page, only supported for MCP2

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PageSize <int>
~~~~~~~~~

The Page Size of the result page, only supported for MCP2

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PoolId <guid>
~~~~~~~~~

The VIP Pool id

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           Filtered     Aliases                      None     Dynamic?                     false





-State <string>
~~~~~~~~~

The VIP Pool state

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           Filtered     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.PoolType


Notes
-----



Examples
---------


