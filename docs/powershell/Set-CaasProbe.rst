
Set-CaasProbe
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasProbe -Network <NetworkWithLocationsNetwork> -Probe <Probe> [-ProbeIntervalSeconds <int>] [-ErrorCountBeforeServerFail <int>] [-SuccessCountBeforeServerEnable <int>] [-FailedProbeIntervalSeconds <int>] [-MaxReplyWaitSeconds <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ErrorCountBeforeServerFail <int>
~~~~~~~~~

The number of errors before declaring a server failure. valid range 1-65535

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-FailedProbeIntervalSeconds <int>
~~~~~~~~~

The number of sucesses before reenable a failed server. valid range 15-65535

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-MaxReplyWaitSeconds <int>
~~~~~~~~~

The max number of seconds to wait for a response from a server. valid range 2-65535

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to manage the VIP settings

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Probe <Probe>
~~~~~~~~~

The Probe object

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ProbeIntervalSeconds <int>
~~~~~~~~~

The interval to probe in seconds. valid range 15-65535

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-SuccessCountBeforeServerEnable <int>
~~~~~~~~~

The number of sucesses before reenable a failed server. valid range 1-65535

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Vip.Probe
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


