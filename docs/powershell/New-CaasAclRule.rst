
New-CaasAclRule
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasAclRule -Network <NetworkWithLocationsNetwork> -AclRuleName <string> -Position <int> -Action <AclActionType> -Protocol <AclProtocolType> [-SourceIpAddress <ipaddress>] [-SourceNetmask <ipaddress>] [-DestinationIpAddress <ipaddress>] [-DestinationNetmask <ipaddress>] [-PortRangeType <PortRangeTypeType>] [-Port1 <int>] [-Port2 <int>] [-AclType <AclType>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-AclRuleName <string>
~~~~~~~~~

The ACL Rule name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-AclType <AclType>
~~~~~~~~~

The type of the ACL. One of OUTSIDE_ACL or INSIDE_ACL. Default is OUTSIDE_ACL.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Action <AclActionType>
~~~~~~~~~

The ACL action type: Permit or Deny

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





-DestinationIpAddress <ipaddress>
~~~~~~~~~

The destination IP Address. If not supplied, ANY IP address is assumed.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-DestinationNetmask <ipaddress>
~~~~~~~~~

The destination Netmask. If supplied with the DestinationIpAddress, represents CIDR boundary for the network.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The target network to add the ACL rule into.

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Port1 <int>
~~~~~~~~~

Depending on the port range type - will define the port criteria

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Port2 <int>
~~~~~~~~~

Depending on the port range type - will define the port criteria

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PortRangeType <PortRangeTypeType>
~~~~~~~~~

The port range type

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Position <int>
~~~~~~~~~

The position of the ACL rule to add

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Protocol <AclProtocolType>
~~~~~~~~~

The protocol

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-SourceIpAddress <ipaddress>
~~~~~~~~~

The source IP Address. If not supplied, ANY IP address is assumed.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-SourceNetmask <ipaddress>
~~~~~~~~~

The source Netmask. If supplied with the SourceIpAddress, represents CIDR boundary for the network.

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network.AclRuleType


Notes
-----



Examples
---------


