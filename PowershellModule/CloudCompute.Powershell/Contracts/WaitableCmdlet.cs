using System;
using System.Management.Automation;
using System.Threading;

namespace DD.CBU.Compute.Powershell.Contracts
{
    using Api.Contracts.Network20;

    public abstract class WaitableCmdlet : PSCmdletCaasWithConnectionBase, IWaitable
    {
        [Parameter(Mandatory = false, HelpMessage = "Wait until provisioned before returning")]
        public SwitchParameter Wait { get; set; }

        protected const int delayTime = 400; 

        protected void WaitForFailureOrCompletion<T>(ResponseType response, Guid objectId)
        {
            if (this.Wait && response != null && response.responseCode == "IN_PROGRESS")
            {
                bool provisioned = false;
                T provisionedObject = default(T);
                
                while (!provisioned)
                {
                    provisioned = WaitOn<T>(objectId, ref provisionedObject);
                    Thread.Sleep(delayTime);
                }
                base.WriteObject(provisionedObject);
            }
            else
            {
                base.WriteObject(response);
            }
        }

        public abstract bool WaitOn<T>(Guid objectId, ref T provisionedObject);
    }

    public interface IWaitable
    {
        bool WaitOn<T>(Guid objectId, ref T provisionedObject);
    }
}
