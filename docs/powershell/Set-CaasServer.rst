
Set-CaasServer
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasServer -Server <ServerType> [-Name <string>] [-Description <string>] [-MemoryInMb <int>] [-CpuCount <int>] [-PrivateIp <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





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





-CpuCount <int>
~~~~~~~~~

Set the number of virtual CPUs.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Description <string>
~~~~~~~~~

Set the server description

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-MemoryInMb <int>
~~~~~~~~~

Set the server RAM memory. Value must be represent a GB integer (e.g. 1024, 2048, 3072, 4096, etc.)

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

Set the server name on CaaS

* Position?                    Named
* Accept pipeline input?       false
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





-PrivateIp <string>
~~~~~~~~~

Set the privateIp of the server

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

The server to action on

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.General.Status


Notes
-----



Examples
---------


