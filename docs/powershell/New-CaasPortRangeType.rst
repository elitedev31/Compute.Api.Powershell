
New-CaasPortRangeType
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasPortRangeType -Begin <uint16> [-End <uint16>] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Begin <uint16>
~~~~~~~~~

The Port Begin of the Range

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

*     Position?                    Named     Accept pipeline input?       true (ByPropertyName)     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





-End <uint16>
~~~~~~~~~

The Port End of the Range

*     Position?                    Named     Accept pipeline input?       false     Parameter set name           (All)     Aliases                      None     Dynamic?                     false





Inputs
------

DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Powershell.Mcp20.Model.PortListPort


Notes
-----



Examples
---------


