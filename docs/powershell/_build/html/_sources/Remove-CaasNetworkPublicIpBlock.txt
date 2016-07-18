Remove-CaasNetworkPublicIpBlock
===================

Synopsis
--------


Remove-CaasNetworkPublicIpBlock -Network <NetworkWithLocationsNetwork> -PublicIpBlock <psobject> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]

Remove-CaasNetworkPublicIpBlock -PublicIpBlock <psobject> -NetworkDomain <NetworkDomainType> [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                            

----------                                                                                                                                                                                                                                            

{@{name=Remove-CaasNetworkPublicIpBlock; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasNetworkPublicIpBlock; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-Confirm <switch>
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      cf
Dynamic?                     false

 
-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to release the public ip addresses

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           MCP1
Aliases                      None
Dynamic?                     false

 
-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain to release the public ip addresses

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           MCP2
Aliases                      None
Dynamic?                     false

 
-PublicIpBlock <psobject>
~~~~~~~~~

The public ip block to be released

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-WhatIf <switch>
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      wi
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
System.Management.Automation.PSObject
DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.General.Status
DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

