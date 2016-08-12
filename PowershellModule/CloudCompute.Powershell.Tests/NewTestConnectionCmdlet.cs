using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell.Tests
{
    /// <summary>
    ///     The new caas Api Proxy Http Client.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TestConnection")]
    [OutputType(typeof(TestCaaSConnection))]
    public class NewTestConnectionCmdlet : PSCmdletCaasBase
    { 
        [Parameter(Mandatory = true, HelpMessage = "Test CaaS Http client")]
        public TestHttpClient TestHttpClient { get; set; }

       
        [Parameter(Mandatory = true, HelpMessage = "CaaS Connection")]
        public ComputeServiceConnection CaaSConnection { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            var testConnection = new TestCaaSConnection(TestHttpClient, CaaSConnection);           
            WriteObject(testConnection);
        }
    }
}
