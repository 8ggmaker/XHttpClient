using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XHttpClient.Rest.Internal
{
    internal class Request : IRequest
    {
        private HttpClientManager httpClientManager;

        private HttpRequestMessage requestMessage;

        Request(HttpClientManager httpClientManager, HttpRequestMessage requestMessage)
        {
            //todo args check

            this.httpClientManager = httpClientManager;
            this.requestMessage = requestMessage;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> ReadResponse<T>()
        {
            throw new NotImplementedException();
        }

        public IRequest WithContent(HttpContent content)
        {
            throw new NotImplementedException();
        }

        public IRequest WithHeaders(IDictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        public IRequest WithQueryString(IDictionary<string, string> queryStrings)
        {
            throw new NotImplementedException();
        }
    }
}
