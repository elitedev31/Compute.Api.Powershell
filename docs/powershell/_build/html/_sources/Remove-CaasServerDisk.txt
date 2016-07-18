Remove-CaasServerDisk
===================

Synopsis
--------


Remove-CaasServerDisk -ScsiId <int> -Server <ServerType> [-PassThru] [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]

Remove-CaasServerDisk -Id <string> -Server <ServerType> [-PassThru] [-Connection <ComputeServiceConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                        

----------                                                                                                                                                                                                                        

{@{name=Remove-CaasServerDisk; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasServerDisk; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-Confirm &lt;switch&gt;
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      cf
Dynamic?                     false

 
-Connection &lt;ComputeServiceConnection&gt;
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Id &lt;string&gt;
~~~~~~~~~

The id of Disk

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_DiskId
Aliases                      None
Dynamic?                     false

 
-PassThru &lt;switch&gt;
~~~~~~~~~

Return the Server object after execution

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ScsiId &lt;int&gt;
~~~~~~~~~

SCSI Id of the disk to be resized

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_SCSIId
Aliases                      None
Dynamic?                     false

 
-Server &lt;ServerType&gt;
~~~~~~~~~

The server to action on

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-WhatIf &lt;switch&gt;
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      wi
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.ServerType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

