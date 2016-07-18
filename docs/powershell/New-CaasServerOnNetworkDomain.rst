New-CaasServerOnNetworkDomain
===================

Synopsis
--------


New-CaasServerOnNetworkDomain -NetworkDomain <NetworkDomainType> -Name <string> -ServerImage <ImagesWithDiskSpeedImage> -IsStarted <bool> -AdminPassword <string> -PrimaryVlan <VlanType> [-Description <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasServerOnNetworkDomain -NetworkDomain <NetworkDomainType> -Name <string> -ServerImage <ImagesWithDiskSpeedImage> -IsStarted <bool> -AdminPassword <string> -PrimaryPrivateIp <string> [-Description <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                        

----------                                                                                                                                                                                                                                        

{@{name=New-CaasServerOnNetworkDomain; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasServerOnNetworkDomain; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-AdminPassword &lt;string&gt;
~~~~~~~~~

The server VM administrator password

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
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

 
-Description &lt;string&gt;
~~~~~~~~~

The server description

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IsStarted &lt;bool&gt;
~~~~~~~~~

The server start flag

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Name &lt;string&gt;
~~~~~~~~~

The server name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-NetworkDomain &lt;NetworkDomainType&gt;
~~~~~~~~~

The network domain in which server will be deployed

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
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

 
-PrimaryPrivateIp &lt;string&gt;
~~~~~~~~~

The private network private IP address that will be assigned to the machine.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           PrivateIp
Aliases                      None
Dynamic?                     false

 
-PrimaryVlan &lt;VlanType&gt;
~~~~~~~~~

The server's primary vlan

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           VlanId
Aliases                      PrimaryNetwork
Dynamic?                     false

 
-ServerImage &lt;ImagesWithDiskSpeedImage&gt;
~~~~~~~~~

The server OS Image

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
System.String
DD.CBU.Compute.Api.Contracts.Image.ImagesWithDiskSpeedImage
System.Boolean
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ServerType


NOTES
-----



EXAMPLES
---------

