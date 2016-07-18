New-CaasVIPVirtualListener
===================

Synopsis
--------


New-CaasVIPVirtualListener -NetworkDomain <NetworkDomainType> -Name <string> -Type <string> -Protocol <string> -ConnectionLimit <int> -ConnectionRateLimit <int> -SourcePortPreservation <string> [-Description <string>] [-IPAddress <string>] [-Port <int>] [-Enabled <bool>] [-PoolId <string>] [-ClientClonePoolId <string>] [-PersistenceProfileId <string>] [-FallbackPersistenceProfileId <string>] [-OptimizationProfileId <string>] [-iRuleId <string[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                            

----------                                                                                                            

{@{name=New-CaasVIPVirtualListener; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-ClientClonePoolId <string>
~~~~~~~~~

The VIP virtual listener Client Clone Pool Id

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

 
-ConnectionLimit <int>
~~~~~~~~~

The VIP virtual listener Connection Limit

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ConnectionRateLimit <int>
~~~~~~~~~

The VIP virtual listener Connection Rate Limit

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Description <string>
~~~~~~~~~

The virtual listener description

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Enabled <bool>
~~~~~~~~~

The VIP virtual listener Status

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-FallbackPersistenceProfileId <string>
~~~~~~~~~

The VIP virtual listener Fallback Persistence Profile Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-IPAddress <string>
~~~~~~~~~

The VIP virtual listener IP Address

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Name <string>
~~~~~~~~~

The virtual listener name

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

 
-OptimizationProfileId <string>
~~~~~~~~~

The VIP virtual listener Optimization Profile Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PersistenceProfileId <string>
~~~~~~~~~

The VIP virtual listener Persistence Profile Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PoolId <string>
~~~~~~~~~

The VIP virtual listener Pool Id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Port <int>
~~~~~~~~~

The VIP virtual listener Port

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Protocol <string>
~~~~~~~~~

The VIP virtual listener Protocol

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-SourcePortPreservation <string>
~~~~~~~~~

The VIP virtual listener Source Port Preservation

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Type <string>
~~~~~~~~~

The VIP virtual listener IP Type

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-iRuleId <string[]>
~~~~~~~~~

The VIP virtual listener iRule Ids

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

