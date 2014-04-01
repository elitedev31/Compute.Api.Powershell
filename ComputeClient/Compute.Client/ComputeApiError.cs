namespace DD.CBU.Compute.Api.Client
{
	/// <summary>
	///		Represents the reason that a <see cref="ComputeApiException"/> was raised.
	/// </summary>
	public enum ComputeApiError
	{
		/// <summary>
		///		An unknown reason.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		///		The CaaS API indicates that the supplied credentials are invalid.
		/// </summary>
		InvalidCredentials = 1,

        /// <summary>
        /// The CaaS API indicates a bad request and return a descriptive (Status) error
        /// </summary>
        BadRequest
	}
}