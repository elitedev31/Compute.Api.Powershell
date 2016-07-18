New-CaasPortList
===================

Synopsis
--------


New-CaasPortList -NetworkDomainId <string> -Name <string> [-Description <string>] [-Port <PortListPort[]>] [-ChildPortListId <string[]>] [-ChildPortList <PortListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasPortList -NetworkDomain <NetworkDomainType> -Name <string> [-Description <string>] [-Port <PortListPort[]>] [-ChildPortListId <string[]>] [-ChildPortList <PortListType[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                              

----------                                                                                                                                                                                                              

{@{name=New-CaasPortList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasPortList; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-ChildPortList &lt;PortListType[]&gt;
~~~~~~~~~

Define one or more individual Port Lists on the same Network Domain

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ChildPortListId &lt;string[]&gt;
~~~~~~~~~

Define one or more individual Port Lists on the same Network Domain

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Connection &lt;ComputeServiceConnection&gt;
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Description &lt;string&gt;
~~~~~~~~~

The Port List description

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Name &lt;string&gt;
~~~~~~~~~

The Port List name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-NetworkDomain &lt;NetworkDomainType&gt;
~~~~~~~~~

The network domain

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           With_NetworkDomain
Aliases                      None
Dynamic?                     false

 
-NetworkDomainId &lt;string&gt;
~~~~~~~~~

The network domain id

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_NetworkDomainId
Aliases                      None
Dynamic?                     false

 
-Port &lt;PortListPort[]&gt;
~~~~~~~~~

Define one or more individual Portes or ranges of Portes. Use New CaasPortRangeType command to create type

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

