// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextMediaTypeFormatter.cs" company="">
//   
// </copyright>
// <summary>
//   The text media type formatter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client
{
	/// <summary>
	/// The text media type formatter.
	/// </summary>
	public class TextMediaTypeFormatter : MediaTypeFormatter
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="TextMediaTypeFormatter"/> class.
		/// </summary>
		public TextMediaTypeFormatter()
		{
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x-www-form-urlencoded"));
		}

		/// <summary>
		/// The read from stream async.
		/// </summary>
		/// <param name="type">
		/// The type.
		/// </param>
		/// <param name="readStream">
		/// The read stream.
		/// </param>
		/// <param name="content">
		/// The content.
		/// </param>
		/// <param name="formatterLogger">
		/// The formatter logger.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, 
			IFormatterLogger formatterLogger)
		{
			var taskCompletionSource = new TaskCompletionSource<object>();
			try
			{
				var memoryStream = new MemoryStream();
				if (readStream != null)
					readStream.CopyTo(memoryStream);
				string s = Encoding.UTF8.GetString(memoryStream.ToArray());
				taskCompletionSource.SetResult(s);
				memoryStream.Dispose();
			}
			catch (Exception e)
			{
				taskCompletionSource.SetException(e);
			}

			return taskCompletionSource.Task;
		}

		/// <summary>
		/// The write to stream async.
		/// </summary>
		/// <param name="type">
		/// The type.
		/// </param>
		/// <param name="value">
		/// The value.
		/// </param>
		/// <param name="writeStream">
		/// The write stream.
		/// </param>
		/// <param name="content">
		/// The content.
		/// </param>
		/// <param name="transportContext">
		/// The transport context.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, 
			TransportContext transportContext)
		{
			var taskCompletionSource = new TaskCompletionSource<object>();
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(value as string);

				if (writeStream != null)
					writeStream.Write(bytes, 0, bytes.Length);

				taskCompletionSource.SetResult(null);
			}
			catch (Exception e)
			{
				taskCompletionSource.SetException(e);
			}

			return taskCompletionSource.Task;
		}

		/// <summary>
		/// The can read type.
		/// </summary>
		/// <param name="type">
		/// The type.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		public override bool CanReadType(Type type)
		{
			return type == typeof (string);
		}

		/// <summary>
		/// The can write type.
		/// </summary>
		/// <param name="type">
		/// The type.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		public override bool CanWriteType(Type type)
		{
			return type == typeof (string);
		}
	}
}