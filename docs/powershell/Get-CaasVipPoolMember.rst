Get-CaasVipPoolMember
===================

Synopsis
--------


Get-CaasVipPoolMember [-NetworkDomain <NetworkDomainType>] [-Datacenter <DatacenterType>] [-VipNode <NodeType>] [-VipPool <PoolType>] [-MemberId <guid>] [-PageNumber <int>] [-PageSize <int>] [-OrderBy <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                       

----------                                                                                                       

{@{name=Get-CaasVipPoolMember; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-Connection &lt;ComputeServiceConnection&gt;
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Datacenter &lt;DatacenterType&gt;
~~~~~~~~~

The data center

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-MemberId &lt;guid&gt;
~~~~~~~~~

The VIP pool member Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-NetworkDomain &lt;NetworkDomainType&gt;
~~~~~~~~~

The network domain

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-OrderBy &lt;string&gt;
~~~~~~~~~

The Order By of the results, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PageNumber &lt;int&gt;
~~~~~~~~~

The Page Number of the result page, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PageSize &lt;int&gt;
~~~~~~~~~

The Page Size of the result page, only supported for MCP2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-VipNode &lt;NodeType&gt;
~~~~~~~~~

The VIP Node

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false

 
-VipPool &lt;PoolType&gt;
~~~~~~~~~

The VIP Pool

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           Filtered
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.PoolMemberType


NOTES
-----



EXAMPLES
---------

