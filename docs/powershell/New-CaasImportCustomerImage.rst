New-CaasImportCustomerImage
===================

Synopsis
--------


New-CaasImportCustomerImage -CustomerImageName <string> -OvfPackage <OvfPackageType> -Network <NetworkWithLocationsNetwork> [-Description <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                             

----------                                                                                                             

{@{name=New-CaasImportCustomerImage; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-CustomerImageName &lt;string&gt;
~~~~~~~~~

The Customer Image name.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Description &lt;string&gt;
~~~~~~~~~

The description

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Network &lt;NetworkWithLocationsNetwork&gt;
~~~~~~~~~

The target data centre location for the customer image.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-OvfPackage &lt;OvfPackageType&gt;
~~~~~~~~~

An OVF Package on the organization’s FTPS account

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

DD.CBU.Compute.Api.Contracts.Server.ServerImageWithStateType


NOTES
-----



EXAMPLES
---------

