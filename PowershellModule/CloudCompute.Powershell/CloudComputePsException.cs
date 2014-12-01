using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell
{
    public class CloudComputePsException:Exception
    {
        public CloudComputePsException(string message) : base(message) {}

    }
}
