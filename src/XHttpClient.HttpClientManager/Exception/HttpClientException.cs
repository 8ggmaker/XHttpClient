using System;
using System.Collections.Generic;
using System.Text;

namespace XHttpClient.Exception
{
    public class HttpClientException: System.Exception
    {
        public Error Error { get; private set; }

        public HttpClientException(Error error, System.Exception innerException)
            : base(error?.ToString(), innerException)
        {
            this.Error = error;
        }
    }
}
