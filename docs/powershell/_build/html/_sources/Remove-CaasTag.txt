Remove-CaasTag
===================

Synopsis
--------


Remove-CaasTag -AssetType <AssetType> -AssetId <string> -TagKeyName <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]

Remove-CaasTag -AssetType <AssetType> -AssetId <string> -TagKeyId <string> [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                          

----------                                                                                                                                                                                                          

{@{name=Remove-CaasTag; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Remove-CaasTag; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-AssetId <string>
~~~~~~~~~

The UUID of the asset

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue, ByPropertyName)
Parameter set name           (All)
Aliases                      Id
Dynamic?                     false

 
-AssetType <AssetType>
~~~~~~~~~

The Asset type

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-TagKeyId <string>
~~~~~~~~~

Value of tagKey Id elements.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_TagKeyId
Aliases                      None
Dynamic?                     false

 
-TagKeyName <string>
~~~~~~~~~

Value of tagKey Name elements.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           With_TagKeyName
Aliases                      None
Dynamic?                     false


INPUTS
------

System.String
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


NOTES
-----



EXAMPLES
---------

