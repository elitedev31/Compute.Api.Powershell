using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client.WebApi
{
    /// <summary>
    /// The CSV Media type formatter
    /// </summary>
    public class CsvMediaTypeFormatter : MediaTypeFormatter
    {
        /// <summary>
        /// Creates a new instance of <see cref="CsvMediaTypeFormatter"/>
        /// </summary>
        public CsvMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/csv"));
        }

        /// <summary>
        /// Creates an instance of <see cref="CsvMediaTypeFormatter"/>
        /// </summary>
        /// <param name="mediaTypeMapping"></param>
        public CsvMediaTypeFormatter(MediaTypeMapping mediaTypeMapping)
            : this()
        {
            MediaTypeMappings.Add(mediaTypeMapping);
        }

        /// <summary>
        /// Creates an instance of <see cref="CsvMediaTypeFormatter"/>
        /// </summary>
        /// <param name="mediaTypeMappings"></param>
        public CsvMediaTypeFormatter(IEnumerable<MediaTypeMapping> mediaTypeMappings)
            : this()
        {
            foreach (var mediaTypeMapping in mediaTypeMappings)
            {
                MediaTypeMappings.Add(mediaTypeMapping);
            }
        }


        /// <summary>
        /// Queries whether this <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter"/> can deserializean object of the specified type.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter"/> can deserialize the type; otherwise, false.
        /// </returns>
        /// <param name="type">The type to deserialize.</param>
        public override bool CanReadType(Type type)
        {
            return true;
        }

        /// <summary>
        /// Queries whether this <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter"/> can serializean object of the specified type.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Net.Http.Formatting.MediaTypeFormatter"/> can serialize the type; otherwise, false.
        /// </returns>
        /// <param name="type">The type to serialize.</param>
        public override bool CanWriteType(Type type)
        {
            return false;
        }

        /// <summary>
        /// Asynchronously deserializes an object of the specified type.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task"/> whose result will be an object of the given type.
        /// </returns>
        /// <param name="type">The type of the object to deserialize.</param><param name="readStream">The <see cref="T:System.IO.Stream"/> to read.</param><param name="content">The <see cref="T:System.Net.Http.HttpContent"/>, if available. It may be null.</param><param name="formatterLogger">The <see cref="T:System.Net.Http.Formatting.IFormatterLogger"/> to log events to.</param><exception cref="T:System.NotSupportedException">Derived types need to support reading.</exception>
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            try
            {
                var memoryStream = new MemoryStream();
                if (readStream != null)
                    readStream.CopyTo(memoryStream);
                var s = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                taskCompletionSource.SetResult(s);
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }

            return taskCompletionSource.Task;
        }
    }
}