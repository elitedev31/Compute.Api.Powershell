$networkname = "Network1"
#this script requires 2 Caas servers to exist: Server1 and Server2

#import Caas Module
Import-Module CaaS

#capture the Caas credentials and create a new Caas conneciton
$login = Get-Credential

New-CaasConnection -ApiCredentials $login -Vendor DimensionData -Region Australia_AU 

#Get the network with a specific name
$network=Get-CaasNetworks -Name $networkname

#get server 1
$server1 = Get-CaasDeployedServer -Network $network -Name "Server1"
#get server 2
$server2 = Get-CaasDeployedServer -Network $network -Name "Server2"

#create 2 real servers
$rserver1=New-CaasRealServer -Network $network -Server $server1 -Name $server1.name -InService $true -PassThru

$rserver2=New-CaasRealServer -Network $network -Server $server2 -Name $server2.name -InService $true -PassThru

#create a new probe (optional) 
#$probe = New-CaasProbe -Network $network -Name "test" -Type TCP -Port 555
#use a existing probe
$probe = Get-CaasProbe -Network $network -Name "tcp"

$serverfarm = New-CaasServerFarm -Network $network -Name "server1-server2" -Predictor LEAST_CONNECTIONS -RealServer $rserver1 -Probe $probe -PassThru
#add the second server to the server farm
Add-CaasToServerFarm -Network $network -ServerFarm $serverfarm -RealServer $rserver2

#add a probe to the server farm
#Add-CaasToServerFarm -Network $network -ServerFarm $serverfarm -Probe $probe

#create new persistence profile
$persprofile=New-CaasPersistenceProfile -Network $network -Name "PersProfile12" -ServerFarm $serverfarm -TimeoutMinutes 30 -CookieName "DCcookie" -CookieType COOKIE_INSERT -PassThru

#create vip
New-CaasVip -Network $network -Name "Vip12" -PersistenceProfile $persprofile -Port 443 -Protocol TCP -InService $true -ReplyToIcmp $true 

#get Vip created 
$vip = Get-CaasVip -Network $network -Name "Vip12"

#create an IP Address with vip ipaddress
$vipIpAddress = New-NetIPAddress -IPAddress $vip.ipAddress

#create ACL rule to permit any connection to the VIP ip address on port 443
New-CaasAclRule -Network $network -AclRuleName "AllowVip444" -Position 202 -Action PERMIT -Protocol TCP -DestinationIpAddress $vipIpAddress -PortRangeType EQUAL_TO -Port1 444


Pause

#Remove created objects
#get all required objects

$aclrule=Get-CaasAclRules -Network $network -Name "AllowVip444"
$vip=get-CaasVip -Network $network -Name "Vip12"
$persprofile=Get-CaasPersistenceProfile -Name "PersProfile12" -Network $network
$serverfarm=Get-CaasServerFarm -Name "server1-server2" -Network $network
$rserver1=Get-CaasRealServer -Network $network  -Name $server1.name 
$rserver2=Get-CaasRealServer -Network $network  -Name $server2.name 
$probe=Get-CaasProbe -Network $network -Name "tcp"

#remove acl
Remove-CaasAclRule -Network $network -AclRule $aclrule
#remove vip
Remove-CaasVip -Network $network -Vip $vip
#remove pesistence profile
Remove-CaasPersistenceProfileCmdlet -Network $network -PersistenceProfile $persprofile
#remove real server from server farm
Remove-CaasFromServerFarm -Network $network -ServerFarm $serverfarm -RealServer $rserver1
Remove-CaasFromServerFarm -Network $network -ServerFarm $serverfarm -RealServer $rserver2
#remove probe from server farm
Remove-CaasFromServerFarm -Network $network -ServerFarm $serverfarm -Probe $probe
#remove server farm
Remove-CaasServerFarm -Network $network -ServerFarm $serverfarm
#remove real servers
Remove-CaasRealServer -Network $network -RealServer $rserver1
Remove-CaasRealServer -Network $network -RealServer $rserver2






