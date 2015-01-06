using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Contracts.Directory;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.New, "CaasAccountRoles")]
    [OutputType(typeof(Role[]))]
    public class NewCaasAccountRolesCmdLet:PsCmdletCaasBase
    {
       [Parameter(Mandatory = false, ParameterSetName = "SubAdministrator",
           HelpMessage = "True of False for network role")]
        public bool Network { get; set; }

       [Parameter(Mandatory = false, ParameterSetName = "SubAdministrator",
        HelpMessage = "True of False for server role")]
       public bool Server { get; set; }

       [Parameter(Mandatory = false, ParameterSetName = "SubAdministrator",
    HelpMessage = "True of False for backup role")]
       public bool Backup { get; set; }

       [Parameter(Mandatory = false, ParameterSetName = "SubAdministrator",
  HelpMessage = "True of False for create image role")]
       public bool CreateImage { get; set; }


       [Parameter(Mandatory = false, ParameterSetName = "SubAdministrator",
  HelpMessage = "True of False for storage role")]
       public bool Storage { get; set; }

       [Parameter(Mandatory = false, ParameterSetName = "SubAdministrator",
HelpMessage = "True of False for reports role")]
       public bool Reports { get; set; }
        
       [Parameter(Mandatory = false, ParameterSetName = "ReadOnly",
HelpMessage = "True of False for reports role")]
       public bool ReadOnly { get; set; }


        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            var roles = new List<Role>();
            if(Network)
                roles.Add(new Role(RoleType.Network));
            if (Backup)
                roles.Add(new Role(RoleType.Backup));
            if (Server)
                roles.Add(new Role(RoleType.Server));
            if (CreateImage)
                roles.Add(new Role(RoleType.Create_Image));
            if (Storage)
                roles.Add(new Role(RoleType.Storage));
            if (Reports)
                roles.Add(new Role(RoleType.Reports));
            if (ReadOnly)
                roles.Add(new Role(RoleType.Read_Only));

            WriteObject(roles.ToArray());


        }
    }
}
