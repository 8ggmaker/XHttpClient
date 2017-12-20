using System;
using System.Collections.Generic;
using System.IO;
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

        public Task<T> ReadAsAsync<T>()
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> ReadAsByteArrayAsync()
        {
            return await this.responseMessage.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
        }

        public async Task<Stream> ReadAsStreamAsync()
        {
            return await this.responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        public async Task<string> ReadAsStringAsync()
        {
            return await this.responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
