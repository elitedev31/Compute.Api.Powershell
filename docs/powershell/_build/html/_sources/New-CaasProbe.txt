New-CaasProbe
===================

Synopsis
--------


New-CaasProbe -Network <NetworkWithLocationsNetwork> -Name <string> -Type <ProbeType> [-Port <int>] [-ProbeIntervalSeconds <int>] [-ErrorCountBeforeServerFail <int>] [-SuccessCountBeforeServerEnable <int>] [-FailedProbeIntervalSeconds <int>] [-MaxReplyWaitSeconds <int>] [-RequestMethod <ProbeRequestMethod>] [-StatusCodeUpperBound <int>] [-StatusCodeLowerBound <int>] [-RequestUrl <string>] [-MatchContent <string>] [-PassThru] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                               

----------                                                                                               

{@{name=New-CaasProbe; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-ErrorCountBeforeServerFail <int>
~~~~~~~~~

The number of errors before declaring a server failure. valid range 1-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-FailedProbeIntervalSeconds <int>
~~~~~~~~~

The number of sucesses before reenable a failed server. valid range 15-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-MatchContent <string>
~~~~~~~~~

Applicable if type is HTTP/HTTPS. The content to be matched.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-MaxReplyWaitSeconds <int>
~~~~~~~~~

The max number of seconds to wait for a response from a server. valid range 2-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Name <string>
~~~~~~~~~

The name for the probe

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network <NetworkWithLocationsNetwork>
~~~~~~~~~

The network to manage the VIP settings

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PassThru <switch>
~~~~~~~~~

Return the Probe object

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Port <int>
~~~~~~~~~

The port to probe. valid range 1-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ProbeIntervalSeconds <int>
~~~~~~~~~

The interval to probe in seconds. valid range 15-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-RequestMethod <ProbeRequestMethod>
~~~~~~~~~

Required if type is HTTP/HTTPS. The request method to be used for the request Url

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-RequestUrl <string>
~~~~~~~~~

Applicable if type is HTTP/HTTPS. The Url to be requested

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-StatusCodeLowerBound <int>
~~~~~~~~~

The upper bound of the HTTP status code to be matched. valid range 0-999

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-StatusCodeUpperBound <int>
~~~~~~~~~

The lower bound of the HTTP status code to be matched. valid range 0-999

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-SuccessCountBeforeServerEnable <int>
~~~~~~~~~

The number of sucesses before reenable a failed server. valid range 1-65535

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Type <ProbeType>
~~~~~~~~~

The type of probe. One of (TCP, UDP, HTTP, HTTPS, ICMP)

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Api.Contracts.Network.NetworkWithLocationsNetwork
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Vip.Probe


NOTES
-----



EXAMPLES
---------

