
Set-CaasServerSpec
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasServerSpec -Server <ServerType> [-MemoryInGb <uint32>] [-CpuCount <uint32>] [-CoresPerSocket <uint32>] [-CpuSpeed <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-CoresPerSocket <uint32>
~~~~~~~~~

Set the number of CPU cores per socket.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-CpuCount <uint32>
~~~~~~~~~

Set the number of virtual CPUs.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-CpuSpeed <string>
~~~~~~~~~

Set the CPU Speed of the server. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.cpuSpeed

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-MemoryInGb <uint32>
~~~~~~~~~

Set the server RAM memory. Value must be represent a GB integer (e.g. 1, 2, 3, 4, etc.)

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PassThru <switch>
~~~~~~~~~

Return the Server object after execution

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

The server to action on

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





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


