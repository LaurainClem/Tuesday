using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Exceptions
{
    public class HttpNotFoundException : HttpResponseException
    {
        public HttpNotFoundException(): base(404, "Not Found")
        {
        }
    }
}
