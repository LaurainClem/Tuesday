using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Exceptions
{
    public class HttpUrlNotValidException : HttpResponseException
    {
        public HttpUrlNotValidException() : base(400, "Url not valid")
        {
        }
    }
}
