
Update-CaasIpAddressList
===================

Synopsis
--------

.. code-block:: powershell
    
    
Update-CaasIpAddressList -Id <guid> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Update-CaasIpAddressList -IpAddressList <IpAddressListType> [-Description <string>] [-IpAddress <IpAddressListRangeType[]>] [-ChildIpAddressListId <string[]>] [-ChildIpAddressList <IpAddressListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-ChildIpAddressList <IpAddressListType[]>
~~~~~~~~~

Define one or more individual IP Address Lists on the same Network Domain

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ChildIpAddressListId <string[]>
~~~~~~~~~

Define one or more individual IP Address Lists on the same Network Domain

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Description <string>
~~~~~~~~~

The IP Address List description

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Id <guid>
~~~~~~~~~

The IP address list id

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_IpAddressListId     Aliases                      None     Dynamic?                     false





-IpAddress <IpAddressListRangeType[]>
~~~~~~~~~

Define one or more individual IP addresses or ranges of IP addresses. Use New-CaasIpAddressRangeType create to create type

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-IpAddressList <IpAddressListType>
~~~~~~~~~

The IP address list

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           With_IpAddressList     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.IpAddressListType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


