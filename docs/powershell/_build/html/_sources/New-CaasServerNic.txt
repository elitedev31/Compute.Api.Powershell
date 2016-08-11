New-CaasServerNic
===================

Synopsis
--------


New-CaasServerNic -Server <ServerType> -Vlan <VlanType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerNic -Server <ServerType> -PrimaryPrivateIp <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerNic -ServerId <string> -Vlan <VlanType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerNic -ServerId <string> -PrimaryPrivateIp <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                                                                                                                                                                                                                          

----------                                                                                                                                                                                                                                                                                                                                                                                                                                          

{@{name=New-CaasServerNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerNic; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-PrimaryPrivateIp <string>
~~~~~~~~~

The private network private IP address that will be assigned to the machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           ServerId_PrivateIp, Server_PrivateIp
Aliases                      None
Dynamic?                     false

 
-Server <ServerType>
~~~~~~~~~

The server on which the nic will be deployed

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           Server_Vlan, Server_PrivateIp
Aliases                      None
Dynamic?                     false

 
-ServerId <string>
~~~~~~~~~

The server ID

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           ServerId_Vlan, ServerId_PrivateIp
Aliases                      None
Dynamic?                     false

 
-Vlan <VlanType>
~~~~~~~~~

The server's primary network

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Server_Vlan, ServerId_Vlan
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

