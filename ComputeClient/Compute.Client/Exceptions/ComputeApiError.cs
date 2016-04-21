// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComputeApiError.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the reason that a <see cref="ComputeApiException" /> was raised.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Api.Client
{
	/// <summary>
	/// Represents the reason that a <see cref="ComputeApiException"/> was raised.
	/// </summary>
	public enum ComputeApiError
	{
		/// <summary>
		/// An unknown reason.
		/// </summary>
		/// <remarks>
		/// Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0, 

		/// <summary>
		/// The CaaS API indicates that the supplied credentials are invalid.
		/// </summary>
		InvalidCredentials = 1,      

        /// <summary>
        /// The CaaS API indicates a bad request and return a descriptive (Status) error
        /// </summary>
        BadRequest = 2,

        /// <summary>
		/// The CaaS API indicates that the supplied credentials are invalid for this org or doesnt have appropriate Role.
		/// </summary>
		PermissionDenied = 3,

        /// <summary>
        /// The CaaS API indicates a service unavailable and return a descriptive (Status) error
        /// </summary>
        ServiceUnavailable = 4,

        /// <summary>
        /// The CaaS API indicates unhandled internal server error
        /// </summary>
        InternalServerError = 5,

        /// <summary>
        /// The CaaS API endpoint not found, typically happens during maintenance
        /// </summary>
        ApiMethodNotFoundError = 6,

        /// <summary>
        /// The CaaS API indicates unhandled Http
        /// </summary>
        HttpException = 7
    }
}