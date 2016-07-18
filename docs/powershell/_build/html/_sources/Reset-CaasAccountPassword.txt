Reset-CaasAccountPassword
===================

Synopsis
--------


Reset-CaasAccountPassword -ApiCredentials <pscredential> -Vendor <KnownApiVendor> -Region <KnownApiRegion> [-NewPassword <securestring>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                           

----------                                                                                                           

{@{name=Reset-CaasAccountPassword; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-ApiCredentials <pscredential>
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-NewPassword <securestring>
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Region <KnownApiRegion>
~~~~~~~~~

A known cloud region for the Cloud API Uri. Not all vendor and region combinations are valid.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Vendor <KnownApiVendor>
~~~~~~~~~

A known cloud vendor for the Cloud API Uri. Not all vendor and region combinations are valid.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

System.Management.Automation.PSCredential


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

