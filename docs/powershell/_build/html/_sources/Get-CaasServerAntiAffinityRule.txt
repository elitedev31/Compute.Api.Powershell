Get-CaasServerAntiAffinityRule
===================

Synopsis
--------


Get-CaasServerAntiAffinityRule [[-RuleId] <string>] [-Network <NetworkWithLocationsNetwork>] [-Location <string>] [-Server <ServerType>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                

----------                                                                                                                

{@{name=Get-CaasServerAntiAffinityRule; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-Location <string>
~~~~~~~~~

filter the location to show the rules

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

filter the network to show the the rules

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-RuleId <string>
~~~~~~~~~

filter the Antiaffinity rule id

.. code-block:: powershell

    Position?                    0
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Server <ServerType>
~~~~~~~~~

find a rule base in a server

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

