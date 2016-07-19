
New-CaasServerAntiAffinityRule
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasServerAntiAffinityRule -Server1 <ServerType> -Server2 <ServerType> [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PassThru <switch>
~~~~~~~~~

Return the  AntiAffinity object after execution

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Server1 <ServerType>
~~~~~~~~~

The server to add to anti affinity rule

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Server2 <ServerType>
~~~~~~~~~

The server to add to anti affinity rule

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


