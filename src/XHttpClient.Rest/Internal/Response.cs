using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XHttpClient.Rest.Internal
{
    internal class Response : IResponse
    {
        private HttpResponseMessage responseMessage;

        public Response(HttpResponseMessage responseMessage)
        {
            this.responseMessage = responseMessage;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> ReadResponseAs<T>()
        {
            throw new NotImplementedException();
        }
    }
}
