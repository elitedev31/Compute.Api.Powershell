
New-CaasIpAddressRangeType
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasIpAddressRangeType -IpAddress <string> [-PrefixSize <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasIpAddressRangeType -Begin <string> -End <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Begin <string>
~~~~~~~~~

The IP Address Begin of the Range

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Range_Ip_Address
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





-End <string>
~~~~~~~~~

The IP Address End of the Range

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Range_Ip_Address
* Aliases                      None
* Dynamic?                     false





-IpAddress <string>
~~~~~~~~~

The IP Address

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Ip_Address
* Aliases                      None
* Dynamic?                     false





-PrefixSize <int>
~~~~~~~~~

The IP Address Range Prefix

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           Ip_Address
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Powershell.Mcp20.Model.IpAddressListRangeType


Notes
-----



Examples
---------


