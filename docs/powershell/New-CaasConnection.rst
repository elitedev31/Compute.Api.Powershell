
New-CaasConnection
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasConnection -ApiCredentials <pscredential> -Region <KnownApiRegion> [-Name <string>] [-Vendor <KnownApiVendor>] [<CommonParameters>]

New-CaasConnection -ApiCredentials <pscredential> -ApiDomainName <string> [-Name <string>] [-FtpDomainName <string>] [<CommonParameters>]





Description
-----------



Parameters
----------




-ApiCredentials <pscredential>
~~~~~~~~~



*     Position?                    Named     Accept pipeline input?       true (ByValue)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-ApiDomainName <string>
~~~~~~~~~

The domain name for the REST API

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           ApiDomainName     Aliases                      None     Dynamic?                     false





-FtpDomainName <string>
~~~~~~~~~

The domain name for the FTP, default is the api domain name

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           ApiDomainName     Aliases                      None     Dynamic?                     false





-Name <string>
~~~~~~~~~

Name to identify this connection

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Region <KnownApiRegion>
~~~~~~~~~

A known cloud region for the Cloud API Uri. Not all vendor and region combinations are valid.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           KnownApiUri     Aliases                      None     Dynamic?                     false





-Vendor <KnownApiVendor>
~~~~~~~~~

A known cloud vendor for the Cloud API Uri. Not all vendor and region combinations are valid.

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           KnownApiUri     Aliases                      None     Dynamic?                     false





Inputs
------

System.Management.Automation.PSCredential


Outputs
-------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Notes
-----



Examples
---------


