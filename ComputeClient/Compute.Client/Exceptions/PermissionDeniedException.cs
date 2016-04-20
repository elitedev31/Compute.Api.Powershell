using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;
	using System.Runtime.Serialization;

    /// <summary>
    /// The CaaS organization not set exception.
    /// </summary>	
    [Serializable]
    public class PermissionDeniedException : ComputeApiWithStatusException
    {		
        /// <summary>
        /// Initialises a new instance of the <see cref="PermissionDeniedException"/> class.
        /// </summary>
        /// <param name="caasOperationStatus">CaaS Operation Details</param>
        /// <param name="uri">
        /// The uri.
        /// </param>
        public PermissionDeniedException(Status caasOperationStatus, Uri uri)
			: base(ComputeApiError.PermissionDenied, caasOperationStatus, uri)
		{
		}

        /// <summary>
        /// Initialises a new instance of the <see cref="PermissionDeniedException"/> class.
        /// </summary>
        /// <param name="caasOperationResponse">CaaS Operation Details</param>
        /// <param name="uri">
        /// The uri.
        /// </param>
        public PermissionDeniedException(ResponseType caasOperationResponse, Uri uri)
            : base(ComputeApiError.PermissionDenied, caasOperationResponse, uri)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PermissionDeniedException"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected PermissionDeniedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{            
		}
	}
}
