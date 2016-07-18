Get-CaasAccounts
===================

Synopsis
--------


Get-CaasAccounts [[-UserName] <string>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                  

----------                                                                                                  

{@{name=Get-CaasAccounts; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-UserName &lt;string&gt;
~~~~~~~~~

Username to filter

.. code-block:: powershell

    Position?                    1
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

DD.CBU.Compute.Api.Contracts.Directory.AccountWithPhoneNumber


NOTES
-----



EXAMPLES
---------

