
New-CaasIpAddressList
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasIpAddressList -NetworkDomainId <string> -Name <string> -IpVersion <IpVersion> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAddressList -NetworkDomain <NetworkDomainType> -Name <string> -IpVersion <IpVersion> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-ChildIpAddressList <IpAddressListType[]>
~~~~~~~~~

The network domain id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ChildIpAddressListId <string[]>
~~~~~~~~~

Define one or more individual IP Address Lists on the same Network Domain

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

The IP Address List description

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-IpAddress <IpAddressListRangeType[]>
~~~~~~~~~

Define one or more individual IP addresses or ranges of IP addresses. Use New CaasIpAddressRangeType to create type

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-IpVersion <IpVersion>
~~~~~~~~~

The IP version (IPv4 / IPv6)

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

The IP Address List name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           With_NetworkDomain
* Aliases                      None
* Dynamic?                     false





-NetworkDomainId <string>
~~~~~~~~~

The network domain id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           With_NetworkDomainId
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


