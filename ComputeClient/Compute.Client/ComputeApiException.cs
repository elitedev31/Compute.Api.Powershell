using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Api.Client
{
	/// <summary>
	///		Exception raised by the CaaS API client when it encounters an error response from the CaaS API.
	/// </summary>
	[Serializable]
	public class ComputeApiException
		: ApiClientException
	{
		/// <summary>
		///		The default additional detail message used if there is no additional error detail available.
		/// </summary>
		public const string			DefaultAdditionalErrorDetailMessage = "No additional information is available.";

		/// <summary>
		///		The reason that the <see cref="ComputeApiException"/> was raised.
		/// </summary>
		readonly ComputeApiError	_error;

		/// <summary>
		///		Additional error detail (if any) provided by the CaaS API.
		/// </summary>
		readonly string	_additionalDetail;

        /// <summary>
        /// The error status of the exception
        /// </summary>
        public  Status Status { get; set; }

	    /// <summary>
	    /// The uri which caused the exception
	    /// </summary>
	    public Uri Uri { get; set; }

		/// <summary>
		///		Create a new <see cref="ComputeApiException"/>.
		/// </summary>
		/// <param name="error">
		///		The reason that the exception is being raised.
		/// </param>
		/// <param name="additionalDetail">
		///		Additional error detail (if any) provided by the CaaS API.
		/// </param>
		/// <param name="messageOrFormat">
		///		The exception message or message format.
		/// </param>
		/// <param name="formatArguments">
		///		Optional message format arguments.
		/// </param>
		public ComputeApiException(ComputeApiError error, string additionalDetail, string messageOrFormat, params object[] formatArguments)
			: base(messageOrFormat, formatArguments)
		{
			Debug.Assert(error != ComputeApiError.Unknown, "Reason.Unknown should not be used here.");
			Debug.Assert(!String.IsNullOrWhiteSpace(messageOrFormat), "Exception message should not be empty.");

			_error = error;
            
			_additionalDetail =
				!String.IsNullOrWhiteSpace(additionalDetail) ?
					additionalDetail
					:
					DefaultAdditionalErrorDetailMessage;
		}

	    ///  <summary>
	    /// 		Create a new <see cref="ComputeApiException"/>.
	    ///  </summary>
	    ///  <param name="error">
	    /// 		The reason that the exception is being raised.
	    ///  </param>
	    ///  <param name="additionalDetail">
	    /// 		Additional error detail (if any) provided by the CaaS API.
	    ///  </param>
	    ///  <param name="messageOrFormat">
	    /// 		The exception message or message format.
	    ///  </param>
	    /// <param name="uri"></param>
	    /// <param name="formatArguments">
	    /// 		Optional message format arguments.
	    ///  </param>
	    /// <param name="status"></param>
	    public ComputeApiException(ComputeApiError error, string additionalDetail, string messageOrFormat, Status status, Uri uri, params object[] formatArguments)
            : base(messageOrFormat, formatArguments)
        {
            Debug.Assert(error != ComputeApiError.Unknown, "Reason.Unknown should not be used here.");
            Debug.Assert(!String.IsNullOrWhiteSpace(messageOrFormat), "Exception message should not be empty.");

            _error = error;
	        Status = status;
	        Uri = uri;

            _additionalDetail =
                !String.IsNullOrWhiteSpace(additionalDetail) ?
                    additionalDetail
                    :
                    DefaultAdditionalErrorDetailMessage;
        }

		/// <summary>
		///		Create a new <see cref="ComputeApiException"/>.
		/// </summary>
		/// <param name="error">
		///		The reason that the exception is being raised.
		/// </param>
		/// <param name="additionalDetail">
		///		Additional error detail (if any) provided by the CaaS API.
		/// </param>
		/// <param name="messageOrFormat">
		///		The exception message or message format.
		/// </param>
		/// <param name="innerException">
		///		A previous exception that caused the current exception to be raised.
		/// </param>
		/// <param name="formatArguments">
		///		Optional message format arguments.
		/// </param>
		public ComputeApiException(ComputeApiError error, string additionalDetail, string messageOrFormat, Exception innerException, params object[] formatArguments)
			: base(messageOrFormat, innerException, formatArguments)
		{
			Debug.Assert(error != ComputeApiError.Unknown, "Reason.Unknown should not be used here.");
			Debug.Assert(!String.IsNullOrWhiteSpace(messageOrFormat), "Exception message should not be empty.");

			_error = error;
			_additionalDetail =
				!String.IsNullOrWhiteSpace(additionalDetail) ?
					additionalDetail
					:
					DefaultAdditionalErrorDetailMessage;
		}

		/// <summary>
		///		Deserialisation constructor for <see cref="ComputeApiException"/>.
		/// </summary>
		/// <param name="info">
		///		A <see cref="SerializationInfo"/> serialisation data store that holds the serialized exception data.
		/// </param>
		/// <param name="context">
		///		A <see cref="StreamingContext"/> value that indicates the source of the serialised data.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		The <paramref name="info"/> parameter is null.
		/// </exception>
		/// <exception cref="SerializationException">
		///		The class name is <c>null</c> or <see cref="Exception.HResult"/> is zero (0).
		/// </exception>
		protected ComputeApiException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			_error = (ComputeApiError)info.GetValue("_error", typeof(ComputeApiError));
			_additionalDetail = info.GetString("_additionalDetail");
		}

		/// <summary>
		///		The reason that the <see cref="ComputeApiException"/> was raised.
		/// </summary>
		public ComputeApiError Error
		{
			get
			{
				return _error;
			}
		}

		/// <summary>
		///		Does the exception include additional error details from the CaaS API?
		/// </summary>
		public bool HaveAdditionalDetail
		{
			get
			{
				return _additionalDetail != DefaultAdditionalErrorDetailMessage;
			}
		}

		/// <summary>
		///		Additional error detail (if any) provided by the CaaS API.
		/// </summary>
		public string AdditionalDetail
		{
			get
			{
				return _additionalDetail;
			}
		}

		/// <summary>
		///		Get exception data for serialisation.
		/// </summary>
		/// <param name="info">
		///		A <see cref="SerializationInfo"/> serialisation data store that will hold the serialized exception data.
		/// </param>
		/// <param name="context">
		///		A <see cref="StreamingContext"/> value that indicates the source of the serialised data.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		The <paramref name="info"/> parameter is null.
		/// </exception>
		/// <exception cref="SerializationException">
		///		The class name is <c>null</c> or <see cref="Exception.HResult"/> is zero (0).
		/// </exception>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			info.AddValue("_error", _error);
			info.AddValue("_additionalDetail", _additionalDetail);

			base.GetObjectData(info, context);
		}
		
		#region Factory methods

		/// <summary>
		///		Create a <see cref="ComputeApiException"/> to be raised because the CaaS API indicates that the supplied credentials are invalid..
		/// </summary>
		/// <param name="loginName">
		///		The login name that the API indicates is invalid.
		/// </param>
		/// <returns>
		///		The configured <see cref="ComputeApiException"/>.
		/// </returns>
		public static ComputeApiException InvalidCredentials(string loginName)
		{
			return new ComputeApiException(
				ComputeApiError.InvalidCredentials,
				String.Format("The supplied login / password for '{0}' is not valid.", loginName),
				"The supplied credentials are not valid."
			);
		}

        /// <summary>
        /// Creates a <see cref="ComputeApiException" /> to be raised because the CaaS API indicates a bad HTTP request
        /// </summary>
        /// <param name="operation">The operation that was attempted</param>
        /// <param name="details">Further error details</param>
        /// <returns>The configured <see cref="ComputeApiException"/></returns>
	    public static ComputeApiException InvalidRequest(string operation, string details)
	    {
	        return new ComputeApiException(
	            ComputeApiError.BadRequest,
	            details,
	            string.Format("The operation {0} failed with an error: {1}", operation, details));
	    }

	    /// <summary>
	    /// Creates a <see cref="ComputeApiException" /> to be raised because the CaaS API indicates a bad HTTP request
	    /// </summary>
	    /// <param name="operation">The operation that was attempted</param>
	    /// <param name="details">Further error details</param>
	    /// <param name="status"></param>
	    /// <param name="uri"></param>
	    /// <returns>The configured <see cref="ComputeApiException"/></returns>
	    public static ComputeApiException InvalidRequest(string operation, string details, Status status, Uri uri)
        {
            return new ComputeApiException(
                ComputeApiError.BadRequest,
                details,
                string.Format("The operation {0} failed with an error: {1}", operation, details),
                status,
                uri);
        }

	    #endregion // Factory methods
	}
}
