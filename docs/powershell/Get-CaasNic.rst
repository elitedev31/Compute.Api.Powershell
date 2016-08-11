
Get-CaasNic
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasNic -Vlan <VlanType> [-Id <guid>] [-ServerId <guid>] [-SecurityGroupId <guid>] [-IsPartOfSecurityGroup <bool>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Get-CaasNic -VlanId <guid> [-Id <guid>] [-ServerId <guid>] [-SecurityGroupId <guid>] [-IsPartOfSecurityGroup <bool>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Id <guid>
~~~~~~~~~

Identifies an individual NIC

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-IsPartOfSecurityGroup <bool>
~~~~~~~~~

Indicates whether or not the given NIC is or is not part of a Security Group

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-OrderBy <string>
~~~~~~~~~

The Order By of the results, only supported for MCP2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PageNumber <int>
~~~~~~~~~

The Page Number of the result page, only supported for MCP2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PageSize <int>
~~~~~~~~~

The Page Size of the result page, only supported for MCP2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-SecurityGroupId <guid>
~~~~~~~~~

Identifies NICs in an individual Security Group

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ServerId <guid>
~~~~~~~~~

Identifies NICs on an individual Server

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Vlan <VlanType>
~~~~~~~~~

Identifies NICs on an individual VLAN

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           With_VLan
* Aliases                      None
* Dynamic?                     false





-VlanId <guid>
~~~~~~~~~

Identifies NICs on an individual VLAN

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           With_VLanId
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.VlanType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.NicWithSecurityGroupType


Notes
-----



Examples
---------


