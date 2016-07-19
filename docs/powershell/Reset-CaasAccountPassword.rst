
Reset-CaasAccountPassword
===================

Synopsis
--------

.. code-block:: powershell
    
    
Reset-CaasAccountPassword -ApiCredentials <pscredential> -Vendor <KnownApiVendor> -Region <KnownApiRegion> [-NewPassword <securestring>] [<CommonParameters>]





Description
-----------



Parameters
----------




-ApiCredentials <pscredential>
~~~~~~~~~



*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-NewPassword <securestring>
~~~~~~~~~



*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Region <KnownApiRegion>
~~~~~~~~~

A known cloud region for the Cloud API Uri. Not all vendor and region combinations are valid.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Vendor <KnownApiVendor>
~~~~~~~~~

A known cloud vendor for the Cloud API Uri. Not all vendor and region combinations are valid.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

System.Management.Automation.PSCredential


Outputs
-------

System.Object

Notes
-----



Examples
---------


