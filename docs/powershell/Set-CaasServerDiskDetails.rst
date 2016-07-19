
Set-CaasServerDiskDetails
===================

Synopsis
--------

.. code-block:: powershell
    
    
Set-CaasServerDiskDetails -ServerDetails <CaasServerDetails> -ScsiId <string> [-SpeedId <string>] [<CommonParameters>]

Set-CaasServerDiskDetails -ServerDetails <CaasServerDetails> -ScsiId <string> [-Speed <DiskSpeedType>] [<CommonParameters>]





Description
-----------



Parameters
----------




-ScsiId <string>
~~~~~~~~~

SCSI ID from the OS or customer image

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-ServerDetails <CaasServerDetails>
~~~~~~~~~

The server details created by New-CaasServerDetails

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Speed <DiskSpeedType>
~~~~~~~~~

The disk speed

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           DiskSpeedType
* Aliases                      None
* Dynamic?                     false





-SpeedId <string>
~~~~~~~~~

The speedId of the new disk. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           SpeedId
* Aliases                      None
* Dynamic?                     false





Inputs
------

None


Outputs
-------

DD.CBU.Compute.Powershell.CaasServerDetails


Notes
-----



Examples
---------


