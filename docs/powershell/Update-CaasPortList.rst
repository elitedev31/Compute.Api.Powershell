
Update-CaasPortList
===================

Synopsis
--------

.. code-block:: powershell
    
    
Update-CaasPortList -Id <guid> [-Description <string>] [-Port <PortListPort[]>] [-ChildPortListId <string[]>] [-ChildPortList <PortListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Update-CaasPortList -PortList <PortListType> [-Description <string>] [-Port <PortListPort[]>] [-ChildPortListId <string[]>] [-ChildPortList <PortListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-ChildPortList <PortListType[]>
~~~~~~~~~

Define one or more individual Port Lists on the same Network Domain

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ChildPortListId <string[]>
~~~~~~~~~

Define one or more individual Port Lists on the same Network Domain

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Description <string>
~~~~~~~~~

The Port List description

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Id <guid>
~~~~~~~~~

The Port list id

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           With_PortListId     Aliases                      None     Dynamic?                     false





-Port <PortListPort[]>
~~~~~~~~~

Define one or more individual Ports or ranges of Ports. Use New CaasPortRangeType command to create type

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-PortList <PortListType>
~~~~~~~~~

The Port list id

*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           With_PortList     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.PortListType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


