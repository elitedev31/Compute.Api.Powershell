// ReSharper disable once CheckNamespace
// Backwards compatibility
namespace DD.CBU.Compute.Api.Client
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// The base class for API client exceptions.
	/// </summary>
	[Serializable]
	public abstract class ApiClientException
		: Exception
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="ApiClientException"/> class. 
		/// Create a new <see cref="ApiClientException"/>.
		/// </summary>
		/// <param name="messageOrFormat">
		/// The exception message or message format.
		/// </param>
		/// <param name="formatArguments">
		/// Optional message format arguments.
		/// </param>
		protected ApiClientException(string messageOrFormat, params object[] formatArguments)
			: base(string.Format(messageOrFormat, formatArguments))
		{		
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ApiClientException"/> class. 
		/// Create a new <see cref="ApiClientException"/>.
		/// </summary>
		/// <param name="messageOrFormat">
		/// The exception message or message format.
		/// </param>
		/// <param name="innerException">
		/// A previous exception that caused the current exception to be raised.
		/// </param>
		/// <param name="formatArguments">
		/// Optional message format arguments.
		/// </param>
		protected ApiClientException(string messageOrFormat, Exception innerException, params object[] formatArguments)
			: base(string.Format(messageOrFormat, formatArguments), innerException)
		{		
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ApiClientException"/> class. 
		/// Deserialisation constructor for <see cref="ApiClientException"/>.
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
		protected ApiClientException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}