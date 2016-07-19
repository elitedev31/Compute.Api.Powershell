
Remove-CaasNetworkPublicIpBlock
===================

Synopsis
--------

.. code-block:: powershell
    
    
Remove-CaasNetworkPublicIpBlock -Network <NetworkWithLocationsNetwork> -PublicIpBlock <psobject> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]

Remove-CaasNetworkPublicIpBlock -PublicIpBlock <psobject> -NetworkDomain <NetworkDomainType> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]





Description
-----------



Parameters
----------




-Confirm <switch>
~~~~~~~~~



*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      cf     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to release the public ip addresses

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           MCP1     Aliases                      None     Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain to release the public ip addresses

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           MCP2     Aliases                      None     Dynamic?                     false





-PublicIpBlock <psobject>
~~~~~~~~~

The public ip block to be released

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-WhatIf <switch>
~~~~~~~~~



*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      wi     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
System.Management.Automation.PSObject
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.General.Status
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


