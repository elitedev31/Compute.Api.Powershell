Set-CaasServer
===================

Synopsis
--------


Set-CaasServer -Server <ServerType> [-Name <string>] [-Description <string>] [-MemoryInMb <int>] [-CpuCount <int>] [-PrivateIp <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                

----------                                                                                                

{@{name=Set-CaasServer; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-CpuCount <int>
~~~~~~~~~

Set the number of virtual CPUs.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Description <string>
~~~~~~~~~

Set the server description

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-MemoryInMb <int>
~~~~~~~~~

Set the server RAM memory. Value must be represent a GB integer (e.g. 1024, 2048, 3072, 4096, etc.)

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Name <string>
~~~~~~~~~

Set the server name on CaaS

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PassThru <switch>
~~~~~~~~~

Return the Server object after execution

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PrivateIp <string>
~~~~~~~~~

Set the privateIp of the server

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Server <ServerType>
~~~~~~~~~

The server to action on

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.General.Status


NOTES
-----



EXAMPLES
---------

