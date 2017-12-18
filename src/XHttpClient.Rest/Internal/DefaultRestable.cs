using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace XHttpClient.Rest.Internal
{
    internal class DefaultRestable:IRestable
    {
        private Uri requestUri;

        private static HttpClientManager httpManager = new HttpClientManager();

        internal DefaultRestable(string requestUri)
        {
            this.requestUri = new Uri(requestUri);
        }

        public IRequest GetRequest(string method)
        {
            throw new NotImplementedException();
        }

        private IRequest GetRequest(HttpMethod method)
        {
            var httpClient = httpManager.GetHttpClient(this.requestUri);
            HttpRequestMessage requestMessage = new HttpRequestMessage(method,requestUri);

            return new Request(httpClient, requestMessage);
        }
    }
}
