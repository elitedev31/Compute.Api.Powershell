
New-CaasServerOnNetworkDomain
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasServerOnNetworkDomain -NetworkDomain <NetworkDomainType> -Name <string> -ServerImage <ImagesWithDiskSpeedImage> -IsStarted <bool> -AdminPassword <string> -PrimaryVlan <VlanType> [-Description <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerOnNetworkDomain -NetworkDomain <NetworkDomainType> -Name <string> -ServerImage <ImagesWithDiskSpeedImage> -IsStarted <bool> -AdminPassword <string> -PrimaryPrivateIp <string> [-Description <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-AdminPassword <string>
~~~~~~~~~

The server VM administrator password

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Description <string>
~~~~~~~~~

The server description

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-IsStarted <bool>
~~~~~~~~~

The server start flag

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

The server name

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain in which server will be deployed

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PassThru <switch>
~~~~~~~~~

Return the Server object after execution

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PrimaryPrivateIp <string>
~~~~~~~~~

The private network private IP address that will be assigned to the machine.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           PrivateIp
* Aliases                      None
* Dynamic?                     false





-PrimaryVlan <VlanType>
~~~~~~~~~

The server's primary vlan

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           VlanId
* Aliases                      PrimaryNetwork
* Dynamic?                     false





-ServerImage <ImagesWithDiskSpeedImage>
~~~~~~~~~

The server OS Image

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
System.String
DD.CBU.Compute.Api.Contracts.Image.ImagesWithDiskSpeedImage
System.Boolean
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ServerType


Notes
-----



Examples
---------


