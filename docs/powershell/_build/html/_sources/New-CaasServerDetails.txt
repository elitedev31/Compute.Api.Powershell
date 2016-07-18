New-CaasServerDetails
===================

Synopsis
--------


New-CaasServerDetails -Name <string> -AdminPassword <string> -IsStarted <bool> -ServerImage <psobject> -Network <NetworkWithLocationsNetwork> [-Description <string>] [<CommonParameters>]

New-CaasServerDetails -Name <string> -AdminPassword <string> -IsStarted <bool> -ServerImage <psobject> -PrimaryVlan <VlanType> -NetworkDomain <NetworkDomainType> [-Description <string>] [-CpuSpeed <string>] [-CpuCount <uint32>] [-CpuCoresPerSocket <uint32>] [-MemoryGb <uint32>] [-PrimaryDns <string>] [-SecondaryDns <string>] [-MicrosoftTimeZone <string>] [<CommonParameters>]

New-CaasServerDetails -Name <string> -AdminPassword <string> -IsStarted <bool> -ServerImage <psobject> -NetworkDomain <NetworkDomainType> -PrivateIp <string> [-Description <string>] [-CpuSpeed <string>] [-CpuCount <uint32>] [-CpuCoresPerSocket <uint32>] [-MemoryGb <uint32>] [-PrimaryDns <string>] [-SecondaryDns <string>] [-MicrosoftTimeZone <string>] [<CommonParameters>]

New-CaasServerDetails -Name <string> -AdminPassword <string> -IsStarted <bool> -ServerImage <psobject> -PrivateIp <string> [-Description <string>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                                                                                                                                                                                                                                          

----------                                                                                                                                                                                                                                                                                                                                                                                                                                                          

{@{name=New-CaasServerDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerDetails; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-AdminPassword &lt;string&gt;
~~~~~~~~~

The VM administrator password

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-CpuCoresPerSocket &lt;uint32&gt;
~~~~~~~~~

The cpu cores per socker for the machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2_WithPrivateIp, MCP2_WithVlan
Aliases                      None
Dynamic?                     false

 
-CpuCount &lt;uint32&gt;
~~~~~~~~~

The cpu count for the machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2_WithVlan, MCP2_WithPrivateIp
Aliases                      None
Dynamic?                     false

 
-CpuSpeed &lt;string&gt;
~~~~~~~~~

The cpu speed for the machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2_WithPrivateIp, MCP2_WithVlan
Aliases                      None
Dynamic?                     false

 
-Description &lt;string&gt;
~~~~~~~~~

The description of the VM

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IsStarted &lt;bool&gt;
~~~~~~~~~

Will the VM be started after deployment (true|false)

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-MemoryGb &lt;uint32&gt;
~~~~~~~~~

The memory size in GB for the machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2_WithPrivateIp, MCP2_WithVlan
Aliases                      None
Dynamic?                     false

 
-MicrosoftTimeZone &lt;string&gt;
~~~~~~~~~

The  Microsoft time zone indec for windows machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2_WithPrivateIp, MCP2_WithVlan
Aliases                      None
Dynamic?                     false

 
-Name &lt;string&gt;
~~~~~~~~~

The VM name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network &lt;NetworkWithLocationsNetwork&gt;
~~~~~~~~~

The network to deploy the machine to.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1_WithNetwork
Aliases                      None
Dynamic?                     false

 
-NetworkDomain &lt;NetworkDomainType&gt;
~~~~~~~~~

The network domain in which server will be deployed

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           MCP2_WithPrivateIp, MCP2_WithVlan
Aliases                      None
Dynamic?                     false

 
-PrimaryDns &lt;string&gt;
~~~~~~~~~

The Primary DNS for the machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2_WithPrivateIp, MCP2_WithVlan
Aliases                      None
Dynamic?                     false

 
-PrimaryVlan &lt;VlanType&gt;
~~~~~~~~~

The server's primary vlan

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2_WithVlan
Aliases                      None
Dynamic?                     false

 
-PrivateIp &lt;string&gt;
~~~~~~~~~

The network private IP address that will be assigned to the machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP1_WithPrivateIp, MCP2_WithPrivateIp
Aliases                      None
Dynamic?                     false

 
-SecondaryDns &lt;string&gt;
~~~~~~~~~

The Secondary DNS for the machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           MCP2_WithPrivateIp, MCP2_WithVlan
Aliases                      None
Dynamic?                     false

 
-ServerImage &lt;psobject&gt;
~~~~~~~~~

The OS or Customer Server Image to use for deployment

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      OsServerImage
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType


OUTPUTS
-------

DD.CBU.Compute.Powershell.CaasServerDetails


NOTES
-----



EXAMPLES
---------

