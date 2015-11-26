New-CaasAccount
===================

## SYNOPSIS

New-CaasAccount -Username <string> -FullName <string> -FirstName <string> -LastName <string> -Password <securestring> -EmailAddress <string> [-Department <string>] [-PhoneCountryCode <string>] [-PhoneNumber <string>] [-CustomDefined1 <string>] [-CustomDefined2 <string>] [-Roles <Role[]>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                 

----------                                                                                                 

{@{name=New-CaasAccount; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -Connection &lt;ComputeServiceConnection&gt;
The CaaS Connection created by New-CaasConnection
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -CustomDefined1 &lt;string&gt;
The account custom defined field 1
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -CustomDefined2 &lt;string&gt;
The account custom defined field 2
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Department &lt;string&gt;
The account department
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -EmailAddress &lt;string&gt;
The account email address
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -FirstName &lt;string&gt;
The account first name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -FullName &lt;string&gt;
The account full name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -LastName &lt;string&gt;
The account last name
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Password &lt;securestring&gt;
The account password
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PhoneCountryCode &lt;string&gt;
The account phone country code address
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -PhoneNumber &lt;string&gt;
The account phone number
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Roles &lt;Role[]&gt;
The roles for this account, use the cmdlet New-CaasAccountRoles to create the values
```
Position?                    Named
Accept pipeline input?       true (ByValue)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Username &lt;string&gt;
The account username.
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
DD.CBU.Compute.Api.Contracts.Directory.Role[]
DD.CBU.Compute.Powershell.ComputeServiceConnection


## OUTPUTS
System.Object

## NOTES


## EXAMPLES
