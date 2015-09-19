// ReSharper disable once CheckNamespace
// Backwards compatibility
namespace DD.CBU.Compute.Api.Client
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Exception raised by the CaaS API client when it encounters an error response from the CaaS API.
	/// </summary>
	[Serializable]
	public class ComputeApiException
		: ApiClientException
	{
		/// <summary>
		/// Gets or sets the error.
		/// </summary>
		public ComputeApiError Error { get; set; }

		/// <summary>
		/// The uri which caused the exception
		/// </summary>
		public Uri Uri { get; set; }

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiException"/> class. 
		/// Create a new <see cref="ComputeApiException"/>.
		/// </summary>
		/// <param name="messageOrFormat">
		/// The exception message or message format.
		/// </param>
		/// <param name="formatArguments">
		/// Optional message format arguments.
		/// </param>
		public ComputeApiException(
			string messageOrFormat,
			params object[] formatArguments)
			: base(messageOrFormat, formatArguments)
		{	
			Error = ComputeApiError.Unknown;
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiException"/> class. 
		/// Create a new <see cref="ComputeApiException"/>.
		/// </summary>
		/// <param name="uri">
		/// Api uri
		/// </param>
		/// <param name="messageOrFormat">
		/// The exception message or message format.
		/// </param>
		/// <param name="formatArguments">
		/// Optional message format arguments.
		/// </param>
		public ComputeApiException(						
			Uri uri,
			string messageOrFormat,	
			params object[] formatArguments)
			: base(messageOrFormat, formatArguments)
		{
			Error = ComputeApiError.Unknown;			
			Uri = uri;
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiException"/> class. 
		/// Create a new <see cref="ComputeApiException"/>.
		/// </summary>
		/// <param name="innerException">
		/// A previous exception that caused the current exception to be raised.
		/// </param>
		/// <param name="messageOrFormat">
		/// The exception message or message format.
		/// </param>
		/// <param name="formatArguments">
		/// Optional message format arguments.
		/// </param>
		public ComputeApiException(					
			Exception innerException,
			string messageOrFormat,
			params object[] formatArguments)
			: base(messageOrFormat, innerException, formatArguments)
		{
			Error = ComputeApiError.Unknown;	
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiException"/> class.
		/// </summary>
		/// <param name="error">
		/// The error.
		/// </param>
		/// <param name="messageOrFormat">
		/// The message or format.
		/// </param>
		/// <param name="formatArguments">
		/// The format arguments.
		/// </param>
		public ComputeApiException(ComputeApiError error, string messageOrFormat, params object[] formatArguments)
			: base(messageOrFormat, formatArguments)
		{
			Error = error;
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ComputeApiException"/> class.
		/// </summary>
		/// <param name="error">
		/// The error.
		/// </param>
		/// <param name="uri">
		/// The uri.
		/// </param>
		/// <param name="messageOrFormat">
		/// The message or format.
		/// </param>
		/// <param name="formatArguments">
		/// The format arguments.
		/// </param>
		public ComputeApiException(				
			ComputeApiError error,
			Uri uri,
			string messageOrFormat,
			params object[] formatArguments)
			: base(messageOrFormat, formatArguments)
		{
			Error = error;
			Uri = uri;
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
		protected ComputeApiException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			Error = (ComputeApiError)info.GetValue("Error", typeof(ComputeApiError));
			Uri = (Uri)info.GetValue("Uri", typeof(Uri));
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
			info.AddValue("Error", Error);					
			info.AddValue("Uri", Uri);
		}

		/// <summary>
		/// Gets a message that describes the current exception.
		/// </summary>
		/// <returns>
		/// The error message that explains the reason for the exception, or an empty string("").
		/// </returns>
		public override string Message
		{
			get
			{
				return String.Format(
				"{0}, Error:{1}, Uri:{2}",
				base.Message,
				Error.ToString(),
				Uri != null ? Uri.ToString() : String.Empty);					
			}
		}
	}
}