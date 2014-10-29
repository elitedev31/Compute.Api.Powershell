#Parameters for the script
param (
[string]$VPNHost = $(throw "-VPNHost is required."),
[string]$username = $(throw "-username is required."),
[string]$password = $(throw "-password is required.")
)

#Please check if file exists on following paths
[string]$vpncliAbsolutePath = 'C:\Program Files (x86)\Cisco\Cisco AnyConnect Secure Mobility Client\vpncli.exe'
[string]$vpnuiAbsolutePath = 'C:\Program Files (x86)\Cisco\Cisco AnyConnect Secure Mobility Client\vpnui.exe'
#Get the system forms assembly
Add-Type -AssemblyName System.Windows.Forms -ErrorAction Stop
#Set foreground window function
#This function is called in VPNConnect
Add-Type @'
using System;
using System.Runtime.InteropServices;
public class Win {
[DllImport("user32.dll")]
[return: MarshalAs(UnmanagedType.Bool)]
public static extern bool SetForegroundWindow(IntPtr hWnd);
}
'@ -ErrorAction Stop

#quickly start VPN
#This function is called later in the code
Function VPNConnect()
{
    Start-Process -FilePath $vpncliAbsolutePath -ArgumentList "connect $VPNHost"
    $counter = 0; $h = 0;
    while($counter++ -lt 1000 -and $h -eq 0)
    {
        sleep -m 20
        $h = (Get-Process vpncli).MainWindowHandle
    }
    #if it takes more than 20 seconds then display message
    if($h -eq 0){echo "Could not start VPNUI it takes too long."}
    else{[void] [Win]::SetForegroundWindow($h)}
}
#Terminate all vpnui processes.
Get-Process | ForEach-Object {
    if($_.ProcessName.ToLower() -eq "vpnui") {
        $Id = $_.Id; Stop-Process $Id; echo "Process vpnui with id: $Id was stopped"}
    }
#Terminate all vpncli processes.
Get-Process | ForEach-Object {
    if($_.ProcessName.ToLower() -eq "vpncli"){
        $Id = $_.Id; Stop-Process $Id; echo "Process vpncli with id: $Id was stopped"
    }
}

#Disconnect from VPN
echo "Trying to terminate remaining vpn connections"
start-Process -FilePath $vpncliAbsolutePath -ArgumentList 'disconnect' -wait
#Connect to VPN
###Err seeking, display the arguments the script got from RDM
echo "Connecting to VPN address '$VPNHost' as user '$username'."
VPNConnect
#Write login and password, sends first one ENTER to accept protocol answer.
#[System.Windows.Forms.SendKeys]::SendWait("{Enter}")
[System.Windows.Forms.SendKeys]::SendWait("$username{Enter}")
[System.Windows.Forms.SendKeys]::SendWait("$Password{Enter}")
#Start vpnui
start-Process -FilePath $vpnuiAbsolutePath