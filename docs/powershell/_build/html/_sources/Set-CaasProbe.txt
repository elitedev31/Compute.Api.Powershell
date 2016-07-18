Set-CaasProbe
===================

Synopsis
--------


Set-CaasProbe -Network <NetworkWithLocationsNetwork> -Probe <Probe> [-ProbeIntervalSeconds <int>] [-ErrorCountBeforeServerFail <int>] [-SuccessCountBeforeServerEnable <int>] [-FailedProbeIntervalSeconds <int>] [-MaxReplyWaitSeconds <int>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                               

----------                                                                                               

{@{name=Set-CaasProbe; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-ErrorCountBeforeServerFail &lt;int&gt;
~~~~~~~~~

The number of errors before declaring a server failure. valid range 1-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-FailedProbeIntervalSeconds &lt;int&gt;
~~~~~~~~~

The number of sucesses before reenable a failed server. valid range 15-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-MaxReplyWaitSeconds &lt;int&gt;
~~~~~~~~~

The max number of seconds to wait for a response from a server. valid range 2-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network &lt;NetworkWithLocationsNetwork&gt;
~~~~~~~~~

The network to manage the VIP settings

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Probe &lt;Probe&gt;
~~~~~~~~~

The Probe object

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ProbeIntervalSeconds &lt;int&gt;
~~~~~~~~~

The interval to probe in seconds. valid range 15-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-SuccessCountBeforeServerEnable &lt;int&gt;
~~~~~~~~~

The number of sucesses before reenable a failed server. valid range 1-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Api.Contracts.Vip.Probe
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

