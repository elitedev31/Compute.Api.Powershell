using System;
using System.Collections.Generic;

namespace DD.CBU.Compute.Powershell
{
    public class CaasServerDetails
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string AdministratorPassword { get; set; }

        public bool IsStarted { get; set; }

        public NetworkWithLocationsNetwork Network { get; set; }

        public DeployedImageWithSoftwareLabelsType OsImage { get; set; }

        public string PrivateIp { get; set; }

        internal List<CaasServerDiskDetails> InternalDiskDetails { get; set; }

        public CaasServerDiskDetails[] DiskDetails
        {
            get
            {
                if (InternalDiskDetails != null)
                    return InternalDiskDetails.ToArray();
                return null;
            }
        
        }

    }
}
