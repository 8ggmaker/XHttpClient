using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace XHttpClient.Internal
{
    internal class DefaultHttpClient : IHttpClient, IDisposable
    {
        private HttpClient httpClient;

        public DefaultHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public DefaultHttpClient(HttpClientHandler httpClientHandler, bool disposeHandler)
        {
            this.httpClient = new HttpClient(httpClientHandler, disposeHandler);
        }

        public Uri BaseAddress
        {
            get
            {
                return this.httpClient.BaseAddress;
            }
            set
            {
                this.httpClient.BaseAddress = value;
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return await this.httpClient.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
        {
            return await this.httpClient.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return await this.httpClient.DeleteAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            return await this.httpClient.DeleteAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await this.httpClient.GetAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption)
        {
            return await this.httpClient.GetAsync(requestUri, completionOption).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return await this.httpClient.GetAsync(requestUri,completionOption,cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            return await this.httpClient.GetAsync(requestUri,cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return await this.httpClient.GetAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption)
        {
            return await this.httpClient.GetAsync(requestUri, completionOption).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return await this.httpClient.GetAsync(requestUri, completionOption, cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return await this.httpClient.GetAsync(requestUri,cancellationToken).ConfigureAwait(false);
        }

        public async Task<byte[]> GetByteArrayAsync(string requestUri)
        {
            return await this.httpClient.GetByteArrayAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<byte[]> GetByteArrayAsync(Uri requestUri)
        {
            return await this.httpClient.GetByteArrayAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<Stream> GetStreamAsync(string requestUri)
        {
            return await this.httpClient.GetStreamAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<Stream> GetStreamAsync(Uri requestUri)
        {
            return await this.httpClient.GetStreamAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<string> GetStringAsync(string requestUri)
        {
            return await this.httpClient.GetStringAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<string> GetStringAsync(Uri requestUri)
        {
            return await this.httpClient.GetStringAsync(requestUri).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return await this.httpClient.PostAsync(requestUri, content).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.httpClient.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return await this.httpClient.PostAsync(requestUri, content).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.httpClient.PostAsync(requestUri,content,cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            return await this.httpClient.PutAsync(requestUri, content).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.httpClient.PutAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            return await this.httpClient.PutAsync(requestUri,content).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await this.httpClient.PutAsync(requestUri,content,cancellationToken).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await this.httpClient.SendAsync(request).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)
        {
            return await this.httpClient.SendAsync(request,completionOption).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return await this.httpClient.SendAsync(request,completionOption,cancellationToken).ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (this.httpClient != null)
            {
                this.httpClient.Dispose();
                this.httpClient = null;
            }
        }
    }
}
