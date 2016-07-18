Set-CaasAccount
===================

Synopsis
--------


Set-CaasAccount -Username <string> [-FullName <string>] [-FirstName <string>] [-LastName <string>] [-Password <securestring>] [-EmailAddress <string>] [-Department <string>] [-PhoneCountryCode <string>] [-PhoneNumber <string>] [-CustomDefined1 <string>] [-CustomDefined2 <string>] [-Roles <Role[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


Syntax
------

.. code-block:: powershell

    syntaxItem                                                                                                 

----------                                                                                                 

{@{name=Set-CaasAccount; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}


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

 
-CustomDefined1 &lt;string&gt;
~~~~~~~~~

The account custom defined field 1

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-CustomDefined2 &lt;string&gt;
~~~~~~~~~

The account custom defined field 2

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Department &lt;string&gt;
~~~~~~~~~

The account department

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-EmailAddress &lt;string&gt;
~~~~~~~~~

The account email address

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-FirstName &lt;string&gt;
~~~~~~~~~

The account first name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-FullName &lt;string&gt;
~~~~~~~~~

The account full name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-LastName &lt;string&gt;
~~~~~~~~~

The account last name

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Password &lt;securestring&gt;
~~~~~~~~~

The account password

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PhoneCountryCode &lt;string&gt;
~~~~~~~~~

The account phone country code address

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-PhoneNumber &lt;string&gt;
~~~~~~~~~

The account phone number

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Roles &lt;Role[]&gt;
~~~~~~~~~

The roles for this account, use the cmdlet New-CaasAccountRoles to create the values

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false

 
-Username &lt;string&gt;
~~~~~~~~~

The account username to be updated

.. code-block:: powershell

    Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false


INPUTS
------

System.String
DD.CBU.Compute.Api.Contracts.Directory.Role[]
DD.CBU.Compute.Powershell.ComputeServiceConnection


OUTPUTS
-------

System.Object

NOTES
-----



EXAMPLES
---------

