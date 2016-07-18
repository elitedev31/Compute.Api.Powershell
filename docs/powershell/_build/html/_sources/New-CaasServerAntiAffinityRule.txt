New-CaasServerAntiAffinityRule
===================

Synopsis
--------


New-CaasServerAntiAffinityRule -Server1 <ServerType> -Server2 <ServerType> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                

----------                                                                                                                

{@{name=New-CaasServerAntiAffinityRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-PassThru &lt;switch&gt;
~~~~~~~~~

Return the  AntiAffinity object after execution

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Server1 &lt;ServerType&gt;
~~~~~~~~~

The server to add to anti affinity rule

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Server2 &lt;ServerType&gt;
~~~~~~~~~

The server to add to anti affinity rule

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Server10.AntiAffinityRuleType


NOTES
-----



EXAMPLES
---------

