
New-CaasNetworkDomain
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasNetworkDomain -Location <string> -Name <string> -Type <NetworkDomainServiceType> [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Description <string>
~~~~~~~~~

The  Network Domain description

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Location <string>
~~~~~~~~~

The network domain location

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Name <string>
~~~~~~~~~

The  Network Domain name

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Type <NetworkDomainServiceType>
~~~~~~~~~

The Network Domain Type

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


