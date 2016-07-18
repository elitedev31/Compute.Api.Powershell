New-CaasAclRule
===================

Synopsis
--------


New-CaasAclRule -Network <NetworkWithLocationsNetwork> -AclRuleName <string> -Position <int> -Action <AclActionType> -Protocol <AclProtocolType> [-SourceIpAddress <ipaddress>] [-SourceNetmask <ipaddress>] [-DestinationIpAddress <ipaddress>] [-DestinationNetmask <ipaddress>] [-PortRangeType <PortRangeTypeType>] [-Port1 <int>] [-Port2 <int>] [-AclType <AclType>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                 

----------                                                                                                 

{@{name=New-CaasAclRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-AclRuleName &lt;string&gt;
~~~~~~~~~

The ACL Rule name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-AclType &lt;AclType&gt;
~~~~~~~~~

The type of the ACL. One of OUTSIDE_ACL or INSIDE_ACL. Default is OUTSIDE_ACL.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Action &lt;AclActionType&gt;
~~~~~~~~~

The ACL action type: Permit or Deny

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

 
-DestinationIpAddress &lt;ipaddress&gt;
~~~~~~~~~

The destination IP Address. If not supplied, ANY IP address is assumed.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-DestinationNetmask &lt;ipaddress&gt;
~~~~~~~~~

The destination Netmask. If supplied with the DestinationIpAddress, represents CIDR boundary for the network.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network &lt;NetworkWithLocationsNetwork&gt;
~~~~~~~~~

The target network to add the ACL rule into.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Port1 &lt;int&gt;
~~~~~~~~~

Depending on the port range type - will define the port criteria

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Port2 &lt;int&gt;
~~~~~~~~~

Depending on the port range type - will define the port criteria

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PortRangeType &lt;PortRangeTypeType&gt;
~~~~~~~~~

The port range type

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Position &lt;int&gt;
~~~~~~~~~

The position of the ACL rule to add

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Protocol &lt;AclProtocolType&gt;
~~~~~~~~~

The protocol

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-SourceIpAddress &lt;ipaddress&gt;
~~~~~~~~~

The source IP Address. If not supplied, ANY IP address is assumed.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-SourceNetmask &lt;ipaddress&gt;
~~~~~~~~~

The source Netmask. If supplied with the SourceIpAddress, represents CIDR boundary for the network.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network.AclRuleType


NOTES
-----



EXAMPLES
---------

