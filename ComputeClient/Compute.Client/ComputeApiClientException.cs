using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;

namespace DD.CBU.Compute.Api.Client
{
    using System.Diagnostics.Contracts;

    /// <summary>
	///		Exception raised by the CaaS API client when it encounters an error.
	/// </summary>
	[Serializable]
	public class ComputeApiClientException
		: ApiClientException
	{
		/// <summary>
		///		The reason that the <see cref="ComputeApiClientException"/> was raised.
		/// </summary>
		readonly ClientError _error;

		/// <summary>
		///		Create a new <see cref="ComputeApiClientException"/>.
		/// </summary>
		/// <param name="error">
		///		The reason that the exception is being raised.
		/// </param>
		/// <param name="messageOrFormat">
		///		The exception message or message format.
		/// </param>
		/// <param name="formatArguments">
		///		Optional message format arguments.
		/// </param>
		public ComputeApiClientException(ClientError error, string messageOrFormat, params object[] formatArguments)
			: base(messageOrFormat, formatArguments)
		{
			Debug.Assert(error != ClientError.Unknown, "Reason.Unknown should not be used here.");
			Debug.Assert(!String.IsNullOrWhiteSpace(messageOrFormat), "Exception message should not be empty.");

			_error = error;
		}

		/// <summary>
		///		Create a new <see cref="ComputeApiClientException"/>.
		/// </summary>
		/// <param name="error">
		///		The reason that the exception is being raised.
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
		public ComputeApiClientException(ClientError error, string messageOrFormat, Exception innerException, params object[] formatArguments)
			: base(messageOrFormat, innerException, formatArguments)
		{
			Debug.Assert(error != ClientError.Unknown, "Reason.Unknown should not be used here.");
			Debug.Assert(!String.IsNullOrWhiteSpace(messageOrFormat), "Exception message should not be empty.");

			_error = error;
		}

		/// <summary>
		///		Deserialisation constructor for <see cref="ComputeApiClientException"/>.
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
		protected ComputeApiClientException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			_error = (ClientError)info.GetValue("_error", typeof(ClientError));
		}

		/// <summary>
		///		The reason that the <see cref="ComputeApiClientException"/> was raised.
		/// </summary>
		public ClientError Error
		{
			get
			{
				return _error;
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

			base.GetObjectData(info, context);
		}

		/// <summary>
		///		Create a string representation of the current exception.
		/// </summary>
		/// <returns>
		///		A string representation of the current exception.
		/// </returns>
		public override string ToString()
		{
			// AF: Revisit - we can do better than this.
			StringBuilder exceptionStringBuilder = new StringBuilder(base.ToString());
			exceptionStringBuilder
				.AppendFormat("API error type: {0}", _error);
			exceptionStringBuilder
				.AppendLine();

			return exceptionStringBuilder.ToString();
		}

		#region Factory methods

		/// <summary>
		///		Create a <see cref="ComputeApiClientException"/> to be raised because the client is not currently logged into the CaaS API.
		/// </summary>
		/// <returns>
		///		The configured <see cref="ComputeApiClientException"/>.
		/// </returns>
		public static ComputeApiClientException NotLoggedIn()
		{
			return new ComputeApiClientException(
				ClientError.NotLoggedIn,
				"The client is not currently logged into the CaaS API (call LoginAsync, first)."
			);
		}

		/// <summary>
		///		Create a <see cref="ComputeApiClientException"/> to be raised because the client is already logged into the CaaS API.
		/// </summary>
		/// <returns>
		///		The configured <see cref="ComputeApiClientException"/>.
		/// </returns>
		public static ComputeApiClientException AlreadyLoggedIn()
		{
			return new ComputeApiClientException(
				ClientError.AlreadyLoggedIn,
				"The client is already logged into the CaaS API (call Logout, first)."
			);
		}

		#endregion // Factory methods
	}
}
