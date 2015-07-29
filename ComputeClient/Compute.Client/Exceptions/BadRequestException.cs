namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	using System.Text;

	using DD.CBU.Compute.Api.Contracts.General;

	using Newtonsoft.Json;

	/// <summary>
	/// The bad request exception.
	/// </summary>
	[Serializable]
	public class BadRequestException : ComputeApiException
	{		
		/// <summary>
		/// Gets or sets the caas operation status. for MCP 1.0 operations
		/// </summary>
		public Status CaaSOperationStatus { get; set; }

		/// <summary>
		/// Gets or sets the caas operation response. for MCP 2.0 operations
		/// </summary>
		public Response CaaSOperationResponse { get; set; }

		/// <summary>
		/// Initialises a new instance of the <see cref="BadRequestException"/> class.
		/// </summary>
		/// <param name="caasOperationStatus">
		/// The caa operation status.
		/// </param>
		/// <param name="uri">
		/// The uri.
		/// </param>
		public BadRequestException(Status caasOperationStatus, Uri uri)
			: base(ComputeApiError.BadRequest, uri, String.Empty)
		{
			CaaSOperationStatus = caasOperationStatus;
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="BadRequestException"/> class.
		/// </summary>
		/// <param name="caasOperationResponse">
		/// The caa operation response.
		/// </param>
		/// <param name="uri">
		/// The uri.
		/// </param>
		public BadRequestException(Response caasOperationResponse, Uri uri)
			: base(ComputeApiError.BadRequest, uri, String.Empty)
		{
			CaaSOperationResponse = caasOperationResponse;
		}

				/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiException"/> class. 
		/// Deserialisation constructor for <see cref="ComputeApiException"/>.
		/// </summary>
		/// <param name="info">
		/// A <see cref="SerializationInfo"/> serialisation data store that holds the serialized exception data.
		/// </param>
		/// <param name="context">
		/// A <see cref="StreamingContext"/> value that indicates the source of the serialised data.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// The <paramref name="info"/> parameter is null.
		/// </exception>
		/// <exception cref="SerializationException">
		/// The class name is <c>null</c> or <see cref="Exception.HResult"/> is zero (0).
		/// </exception>
		protected BadRequestException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			CaaSOperationStatus = (Status)info.GetValue("CaaSOperationStatus", typeof(Status));
			CaaSOperationResponse = (Response)info.GetValue("CaaSOperationResponse", typeof(Response));
		}
		
		/// <summary>
		/// Get exception data for serialisation.
		/// </summary>
		/// <param name="info">
		/// A <see cref="SerializationInfo"/> serialisation data store that will hold the serialized exception data.
		/// </param>
		/// <param name="context">
		/// A <see cref="StreamingContext"/> value that indicates the source of the serialised data.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// The <paramref name="info"/> parameter is null.
		/// </exception>
		/// <exception cref="SerializationException">
		/// The class name is <c>null</c> or <see cref="Exception.HResult"/> is zero (0).
		/// </exception>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			base.GetObjectData(info, context);
			info.AddValue("CaaSOperationStatus", CaaSOperationStatus);
			info.AddValue("CaaSOperationResponse", CaaSOperationResponse);
		}

		/// <summary>
		/// Gets the message.
		/// </summary>
		public override string Message
		{
			get
			{
				StringBuilder sb = new StringBuilder(base.Message);

				if (CaaSOperationStatus != null)
				{
					sb.AppendFormat("CaaSOperationStatus: {0}", JsonConvert.SerializeObject(CaaSOperationStatus));
				}
				if (CaaSOperationResponse != null)
				{
					sb.AppendFormat("CaaSOperationResponse: {0}", JsonConvert.SerializeObject(CaaSOperationResponse));
				}
				return sb.ToString();
			}
		}
	}
}
