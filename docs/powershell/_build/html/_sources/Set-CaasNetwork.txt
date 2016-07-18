Set-CaasNetwork
===================

Synopsis
--------


Set-CaasNetwork -Network <NetworkWithLocationsNetwork> [-Name <string>] [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Set-CaasNetwork -Network <NetworkWithLocationsNetwork> [-Multicast <bool>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                            

----------                                                                                                                                                                                                            

{@{name=Set-CaasNetwork; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Set-CaasNetwork; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

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

Set the new description for the network

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           NetworkName
Aliases                      None
Dynamic?                     false

 
-Multicast &lt;bool&gt;
~~~~~~~~~

Enable/Disable multicast on the network

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Multicast
Aliases                      None
Dynamic?                     false

 
-Name &lt;string&gt;
~~~~~~~~~

Set new name for the network

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           NetworkName
Aliases                      None
Dynamic?                     false

 
-Network &lt;NetworkWithLocationsNetwork&gt;
~~~~~~~~~

Set the server name on CaaS

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

