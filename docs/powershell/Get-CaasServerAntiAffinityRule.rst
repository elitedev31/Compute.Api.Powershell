
Get-CaasServerAntiAffinityRule
===================

Synopsis
--------

.. code-block:: powershell
    
    
Get-CaasServerAntiAffinityRule [[-RuleId] <string>] [-Network <NetworkWithLocationsNetwork>] [-Location <string>] [-Server <ServerType>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Location <string>
~~~~~~~~~

filter the location to show the rules

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

filter the network to show the the rules

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-RuleId <string>
~~~~~~~~~

filter the Antiaffinity rule id

*     Position?                    0     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Server <ServerType>
~~~~~~~~~

find a rule base in a server

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Server10.AntiAffinityRuleType


Notes
-----



Examples
---------


