
New-CaasIpAndPortType
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasIpAndPortType -IpAddressList <IpAddressListType> -PortList <PortListType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAndPortType -IpAddressList <IpAddressListType> [-BeginPort <uint16>] [-EndPort <uint16>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAndPortType -IpAddress <string> -PortList <PortListType> [-PrefixSize <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAndPortType -IpAddress <string> [-PrefixSize <int>] [-BeginPort <uint16>] [-EndPort <uint16>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-BeginPort <uint16>
~~~~~~~~~

The Port

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_IpAddress_Port, With_IpAddressList_Port     Aliases                      None     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-EndPort <uint16>
~~~~~~~~~

The Port rang end

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_IpAddressList_Port, With_IpAddress_Port     Aliases                      None     Dynamic?                     false





-IpAddress <string>
~~~~~~~~~

The IP Address

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_IpAddress_PortList, With_IpAddress_Port     Aliases                      None     Dynamic?                     false





-IpAddressList <IpAddressListType>
~~~~~~~~~

The IP Address List

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_IpAddressList_PortList, With_IpAddressList_Port     Aliases                      None     Dynamic?                     false





-PortList <PortListType>
~~~~~~~~~

The Port List

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_IpAddressList_PortList, With_IpAddress_PortList     Aliases                      None     Dynamic?                     false





-PrefixSize <int>
~~~~~~~~~

The IP Address Prefix Size

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_IpAddress_Port, With_IpAddress_PortList     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.IpAndPortType


Notes
-----



Examples
---------


