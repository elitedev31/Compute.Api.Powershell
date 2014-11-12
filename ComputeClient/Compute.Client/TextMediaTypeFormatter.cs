using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client
{
    public class TextMediaTypeFormatter : MediaTypeFormatter
    {
        public TextMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x-www-form-urlencoded"));
        }

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

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, System.Net.TransportContext transportContext)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            try
            {

                var bytes = System.Text.Encoding.UTF8.GetBytes(value as string);

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

        public override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(string);
        }
    }

}
