/* 
This file is auto generated using the follwing url: http://json2csharp.com/
 providing the follwing input:
[
  {
    "@id": "15136cef-1daa-4e92-80a6-c79e24f8f450",
    "@location": "AU6",
    "name": "AUCALLMGR01",
    "description": "sfdsdfsfdsfd",
    "operatingSystem": {
      "@id": "REDHAT664",
      "@displayName": "REDHAT6/64",
      "@type": "UNIX"
    },
    "cpuCount": "2",
    "memoryMb": "4096",
    "disk": {
      "@id": "f72f222c-34ed-47ab-86d4-4b841a1aa917",
      "@scsiId": "0",
      "@sizeGb": "10",
      "@speed": "STANDARD",
      "@state": "NORMAL"
    },
    "sourceImageId": "30e8ea72-10a8-11e3-9153-001b21cfdbe0",
    "networkId": "89e98c4c-6c86-11e2-9153-001b21cfdbe0",
    "machineName": "10-209-170-11",
    "privateIp": "10.209.170.11",
    "created": "2014-03-10T00:46:06.000Z",
    "isDeployed": "true",
    "isStarted": "false",
    "state": "NORMAL",
    "machineStatus": [
      {
        "@name": "vmwareToolsVersionStatus",
        "value": "NEED_UPGRADE"
      },
      {
        "@name": "vmwareToolsRunningStatus",
        "value": "NOT_RUNNING"
      },
      {
        "@name": "vmwareToolsApiVersion",
        "value": "8394"
      }
    ]
  },
  {
    "@id": "2dab7fd8-d369-4c36-8268-a32ae671c890",
    "@location": "AU6",
    "name": "AUCALLMGR02",
    "description": null,
    "operatingSystem": {
      "@id": "REDHAT632",
      "@displayName": "REDHAT6/32",
      "@type": "UNIX"
    },
    "cpuCount": "1",
    "memoryMb": "2048",
    "disk": {
      "@id": "1f5e0670-464b-4253-9bf5-425aefee575a",
      "@scsiId": "0",
      "@sizeGb": "10",
      "@speed": "STANDARD",
      "@state": "NORMAL"
    },
    "sourceImageId": "30f89c74-10a8-11e3-9153-001b21cfdbe0",
    "networkId": "89e98c4c-6c86-11e2-9153-001b21cfdbe0",
    "machineName": "10-209-170-12",
    "privateIp": "10.209.170.12",
    "created": "2014-03-10T00:59:20.000Z",
    "isDeployed": "true",
    "isStarted": "false",
    "state": "NORMAL",
    "machineStatus": [
      {
        "@name": "vmwareToolsVersionStatus",
        "value": "NEED_UPGRADE"
      },
      {
        "@name": "vmwareToolsRunningStatus",
        "value": "NOT_RUNNING"
      },
      {
        "@name": "vmwareToolsApiVersion",
        "value": "8394"
      }
    ]
  }
]
 */

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

public class OperatingSystem
{
    public string id { get; set; }
    public string displayName { get; set; }
    public string type { get; set; }
}

public class Disk
{
    public string id { get; set; }
    public string scsiId { get; set; }
    public string sizeGb { get; set; }
    public string speed { get; set; }
    public string state { get; set; }
}

public class MachineStatu
{
    public string name { get; set; }
    public string value { get; set; }
}

public class NetworkServer
{
    public string id { get; set; }
    public string location { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public OperatingSystem operatingSystem { get; set; }
    public string cpuCount { get; set; }
    public string memoryMb { get; set; }
    public Disk disk { get; set; }
    public string sourceImageId { get; set; }
    public string networkId { get; set; }
    public string machineName { get; set; }
    public string privateIp { get; set; }
    public string created { get; set; }
    public string isDeployed { get; set; }
    public string isStarted { get; set; }
    public string state { get; set; }
    public List<MachineStatu> machineStatus { get; set; }
}
