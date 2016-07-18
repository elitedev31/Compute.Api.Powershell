New-CaasIpAddressRangeType
===================

Synopsis
--------


New-CaasIpAddressRangeType -IpAddress <string> [-PrefixSize <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAddressRangeType -Begin <string> -End <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                                  

----------                                                                                                                                                                                                                                  

{@{name=New-CaasIpAddressRangeType; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasIpAddressRangeType; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-Begin &lt;string&gt;
~~~~~~~~~

The IP Address Begin of the Range

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Range_Ip_Address
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

 
-End &lt;string&gt;
~~~~~~~~~

The IP Address End of the Range

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Range_Ip_Address
Aliases                      None
Dynamic?                     false

 
-IpAddress &lt;string&gt;
~~~~~~~~~

The IP Address

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Ip_Address
Aliases                      None
Dynamic?                     false

 
-PrefixSize &lt;int&gt;
~~~~~~~~~

The IP Address Range Prefix

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Ip_Address
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Powershell.Mcp20.Model.IpAddressListRangeType


NOTES
-----



EXAMPLES
---------

