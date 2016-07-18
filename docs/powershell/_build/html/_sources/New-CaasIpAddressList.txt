New-CaasIpAddressList
===================

Synopsis
--------


New-CaasIpAddressList -NetworkDomainId <string> -Name <string> -IpVersion <IpVersion> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAddressList -NetworkDomain <NetworkDomainType> -Name <string> -IpVersion <IpVersion> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                        

----------                                                                                                                                                                                                                        

{@{name=New-CaasIpAddressList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasIpAddressList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-ChildIpAddressList <IpAddressListType[]>
~~~~~~~~~

The network domain id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ChildIpAddressListId <string[]>
~~~~~~~~~

Define one or more individual IP Address Lists on the same Network Domain

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Description <string>
~~~~~~~~~

The IP Address List description

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IpAddress <IpAddressListRangeType[]>
~~~~~~~~~

Define one or more individual IP addresses or ranges of IP addresses. Use New CaasIpAddressRangeType to create type

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IpVersion <IpVersion>
~~~~~~~~~

The IP version (IPv4 / IPv6)

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Name <string>
~~~~~~~~~

The IP Address List name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           With_NetworkDomain
Aliases                      None
Dynamic?                     false

 
-NetworkDomainId <string>
~~~~~~~~~

The network domain id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_NetworkDomainId
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

