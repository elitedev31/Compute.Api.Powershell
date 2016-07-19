
Set-CaasAccount
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasAccount -Username <string> [-FullName <string>] [-FirstName <string>] [-LastName <string>] [-Password <securestring>] [-EmailAddress <string>] [-Department <string>] [-PhoneCountryCode <string>] [-PhoneNumber <string>] [-CustomDefined1 <string>] [-CustomDefined2 <string>] [-Roles <Role[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-CustomDefined1 <string>
~~~~~~~~~

The account custom defined field 1

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-CustomDefined2 <string>
~~~~~~~~~

The account custom defined field 2

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Department <string>
~~~~~~~~~

The account department

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-EmailAddress <string>
~~~~~~~~~

The account email address

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-FirstName <string>
~~~~~~~~~

The account first name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-FullName <string>
~~~~~~~~~

The account full name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-LastName <string>
~~~~~~~~~

The account last name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Password <securestring>
~~~~~~~~~

The account password

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PhoneCountryCode <string>
~~~~~~~~~

The account phone country code address

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PhoneNumber <string>
~~~~~~~~~

The account phone number

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Roles <Role[]>
~~~~~~~~~

The roles for this account, use the cmdlet New-CaasAccountRoles to create the values

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Username <string>
~~~~~~~~~

The account username to be updated

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

System.String
DD.CBU.Compute.Api.Contracts.Directory.Role[]
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

System.Object

Notes
-----



Examples
---------


