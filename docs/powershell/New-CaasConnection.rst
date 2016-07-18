New-CaasConnection
===================

Synopsis
--------


New-CaasConnection -ApiCredentials <pscredential> -Region <KnownApiRegion> [-Name <string>] [-Vendor <KnownApiVendor>] [<CommonParameters>]

New-CaasConnection -ApiCredentials <pscredential> -ApiDomainName <string> [-Name <string>] [-FtpDomainName <string>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                                                                                                                                  

----------                                                                                                                                                                                                                  

{@{name=New-CaasConnection; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=New-CaasConnection; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


Description
-----------



Parameters
----------

-ApiCredentials &lt;pscredential&gt;
~~~~~~~~~



.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-ApiDomainName &lt;string&gt;
~~~~~~~~~

The domain name for the REST API

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           ApiDomainName
Aliases                      None
Dynamic?                     false

 
-FtpDomainName &lt;string&gt;
~~~~~~~~~

The domain name for the FTP, default is the api domain name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           ApiDomainName
Aliases                      None
Dynamic?                     false

 
-Name &lt;string&gt;
~~~~~~~~~

Name to identify this connection

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Region &lt;KnownApiRegion&gt;
~~~~~~~~~

A known cloud region for the Cloud API Uri. Not all vendor and region combinations are valid.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           KnownApiUri
Aliases                      None
Dynamic?                     false

 
-Vendor &lt;KnownApiVendor&gt;
~~~~~~~~~

A known cloud vendor for the Cloud API Uri. Not all vendor and region combinations are valid.

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           KnownApiUri
Aliases                      None
Dynamic?                     false


INPUTS
------

System.Management.Automation.PSCredential


OUTPUTS
-------

DD.CBU.Compute.Powershell.ComputeServiceConnection


NOTES
-----



EXAMPLES
---------

