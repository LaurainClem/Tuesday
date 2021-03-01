using System;
using System.Runtime.Serialization;

namespace Tuesday.Controllers
{
    [Serializable]
    internal class HttpResponseController : Exception
    {
        public HttpResponseController()
        {
        }

        public HttpResponseController(string message) : base(message)
        {
        }

        public HttpResponseController(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseController(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}