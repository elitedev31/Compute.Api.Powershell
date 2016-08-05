using System;
using System.Management.Automation;
using System.Threading;

namespace DD.CBU.Compute.Powershell.Contracts
{
    using Api.Client;
    using Api.Contracts.Generic;
    using Api.Contracts.Network20;

    public abstract class WaitableCmdlet : PSCmdletCaasWithConnectionBase, IWaitable
    {
        [Parameter(Mandatory = false, HelpMessage = "Wait until provisioned before returning")]
        public SwitchParameter Wait { get; set; }

        protected const int delayTime = 400; 

        protected void WaitForFailureOrCompletion(ResponseType response, Guid objectId)
        {
            if (this.Wait && response != null && response.responseCode == "IN_PROGRESS")
            {
                bool provisioned = false;
                IEntityStatusV2 provisionedObject = default(IEntityStatusV2);
                
                while (!provisioned)
                {
                    Update(objectId, ref provisionedObject);
                    if (provisionedObject.state == "FAILED")
                        ThrowTerminatingError(
                           new ErrorRecord(new ComputeApiException(string.Format("Failed to provision {0}", provisionedObject.state)), "-1", ErrorCategory.ConnectionError, Connection));

                    provisioned = (provisionedObject.state != "IN_PROGRESS" && provisionedObject.state != "PENDING_ADD");
                    if (!provisioned)
                        Thread.Sleep(delayTime);
                }
                base.WriteObject(provisionedObject);
            }
            else
            {
                base.WriteObject(response);
            }
        }

        public abstract void Update(Guid objectId, ref IEntityStatusV2 provisionedObject);
    }

    public interface IWaitable
    {
        void Update(Guid objectId, ref IEntityStatusV2 provisionedObject);
    }
}
