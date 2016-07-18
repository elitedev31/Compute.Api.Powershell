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

-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ConnectionLimit <int>
~~~~~~~~~

The VIP Node Connection Limit

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ConnectionRateLimit <int>
~~~~~~~~~

The VIP Node Connection Rate Limit

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Description <string>
~~~~~~~~~

The Node description

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Enabled <bool>
~~~~~~~~~

The VIP Node Status

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-HealthMonitorId <string>
~~~~~~~~~

The VIP Node Health Monitor Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IPAddress <string>
~~~~~~~~~

The VIP Node IP Address

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IPType <IpItemChoiceType>
~~~~~~~~~

The VIP Node IP Type

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
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-NodeName <string>
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

