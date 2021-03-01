using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Exceptions
{
    public class HttpInternalErrorException : HttpResponseException
    {
        public HttpInternalErrorException() : base(500, "Internal Error")
        {
        }
    }
}
