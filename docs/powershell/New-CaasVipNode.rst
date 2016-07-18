New-CaasVipNode
===================

Synopsis
--------


New-CaasVipNode -NetworkDomain <NetworkDomainType> -NodeName <string> -IPType <IpItemChoiceType> -IPAddress <string> -Enabled <bool> -ConnectionLimit <int> -ConnectionRateLimit <int> [-Description <string>] [-HealthMonitorId <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                 

----------                                                                                                 

{@{name=New-CaasVipNode; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-ConnectionLimit &lt;int&gt;
~~~~~~~~~

The VIP Node Connection Limit

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ConnectionRateLimit &lt;int&gt;
~~~~~~~~~

The VIP Node Connection Rate Limit

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Description &lt;string&gt;
~~~~~~~~~

The Node description

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Enabled &lt;bool&gt;
~~~~~~~~~

The VIP Node Status

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-HealthMonitorId &lt;string&gt;
~~~~~~~~~

The VIP Node Health Monitor Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IPAddress &lt;string&gt;
~~~~~~~~~

The VIP Node IP Address

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IPType &lt;IpItemChoiceType&gt;
~~~~~~~~~

The VIP Node IP Type

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-NetworkDomain &lt;NetworkDomainType&gt;
~~~~~~~~~

The network domain

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-NodeName &lt;string&gt;
~~~~~~~~~

The VIP Node name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
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

