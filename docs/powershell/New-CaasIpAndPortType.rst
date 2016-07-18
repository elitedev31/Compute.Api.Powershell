New-CaasIpAndPortType
===================

Synopsis
--------


New-CaasIpAndPortType -IpAddressList <IpAddressListType> -PortList <PortListType> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAndPortType -IpAddressList <IpAddressListType> [-BeginPort <uint16>] [-EndPort <uint16>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAndPortType -IpAddress <string> -PortList <PortListType> [-PrefixSize <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAndPortType -IpAddress <string> [-PrefixSize <int>] [-BeginPort <uint16>] [-EndPort <uint16>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                                                                                                                                                                                                                                          

----------                                                                                                                                                                                                                                                                                                                                                                                                                                                          

{@{name=New-CaasIpAndPortType; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasIpAndPortType; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasIpAndPortType; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasIpAndPortType; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-BeginPort &lt;uint16&gt;
~~~~~~~~~

The Port

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_IpAddress_Port, With_IpAddressList_Port
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

 
-EndPort &lt;uint16&gt;
~~~~~~~~~

The Port rang end

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_IpAddressList_Port, With_IpAddress_Port
Aliases                      None
Dynamic?                     false

 
-IpAddress &lt;string&gt;
~~~~~~~~~

The IP Address

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_IpAddress_PortList, With_IpAddress_Port
Aliases                      None
Dynamic?                     false

 
-IpAddressList &lt;IpAddressListType&gt;
~~~~~~~~~

The IP Address List

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_IpAddressList_PortList, With_IpAddressList_Port
Aliases                      None
Dynamic?                     false

 
-PortList &lt;PortListType&gt;
~~~~~~~~~

The Port List

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_IpAddressList_PortList, With_IpAddress_PortList
Aliases                      None
Dynamic?                     false

 
-PrefixSize &lt;int&gt;
~~~~~~~~~

The IP Address Prefix Size

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_IpAddress_Port, With_IpAddress_PortList
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.IpAndPortType


NOTES
-----



EXAMPLES
---------

