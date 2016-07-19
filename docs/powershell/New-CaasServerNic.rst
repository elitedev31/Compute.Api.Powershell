
New-CaasServerNic
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasServerNic -Server <ServerType> -PrimaryPrivateIp <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerNic -Server <ServerType> -Vlan <VlanType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerNic -ServerId <string> -PrimaryPrivateIp <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerNic -ServerId <string> -Vlan <VlanType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PrimaryPrivateIp <string>
~~~~~~~~~

The private network private IP address that will be assigned to the machine.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           Server_PrivateIp, ServerId_PrivateIp     Aliases                      None     Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

The server on which the nic will be deployed

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           Server_PrivateIp, Server_Vlan     Aliases                      None     Dynamic?                     false





-ServerId <string>
~~~~~~~~~

The server ID

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           ServerId_PrivateIp, ServerId_Vlan     Aliases                      None     Dynamic?                     false





-Vlan <VlanType>
~~~~~~~~~

The server's primary network

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           ServerId_Vlan, Server_Vlan     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


