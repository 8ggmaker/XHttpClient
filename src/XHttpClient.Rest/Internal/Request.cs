using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using XHttpClient.Exception;

namespace XHttpClient.Rest.Internal
{
    
    internal class EntityHeader
    {
        /// <summary>
        /// ref:https://www.w3.org/Protocols/rfc2616/rfc2616-sec7.html#sec7.1
        /// </summary>
        private static HashSet<string> entityHeaders = new HashSet<string>{"content-type","content-length",
            "content-range","content-encoding","content-language","content-location","content-md5","expires",
            "last-modified","extension-header"};
    }

    internal class Request : IRequest
    {
        private bool disposed = false;

        private IHttpClient httpClient;

        private HttpRequestMessage requestMessage;

        private IEnumerable<HttpStatusCode> validStatusCodes = new HttpStatusCode[] { HttpStatusCode.OK };

        private CancellationToken cancellationToken = CancellationToken.None;

        private Action requestCancelCallBack;

        internal Request(IHttpClient httpClient, HttpRequestMessage requestMessage)
        {
            this.httpClient = httpClient ?? throw new HttpClientException(new Error
            {
                Code = ErrorCode.ArgsNullException.ToString(),
                Message = "httpclient is null"
            });

            this.requestMessage = requestMessage ?? throw new HttpClientException(new Error
            {
                Code = ErrorCode.ArgsNullException.ToString(),
                Message = $"http request message is null"
            });
        }

        public IRequest WithAuthentication(string scheme, string parameter)
        {
            this.requestMessage.Headers.Authorization = new AuthenticationHeaderValue(scheme, parameter);
            return this;
        }

        public IRequest WithBearerAuthentication(string parameter)
        {
            this.WithAuthentication("Bearer", parameter);
            return this;
        }

        public IRequest WithContent(HttpContent content)
        {
            if (content != null)
            {
                this.requestMessage.Content = content;
            }
            return this;
        }

        public IRequest WithContentType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new HttpClientException(new Error
                {
                    Code = ErrorCode.ArgsNullException.ToString(),
                    Message = "content-type is null or empty"
                });
            }

            this.requestMessage.Headers.Add("Content-Type", type);
            return this;
        }

        public IRequest WithHeaders(IDictionary<string, string> headers)
        {
            if (headers != null)
            {
                using (var enumerator = headers.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        var keyvalPair = enumerator.Current;
                        this.requestMessage.Headers.Add(keyvalPair.Key, keyvalPair.Value);
                    }
                }
            }

            return this;
        }

        public IRequest WithQueryString(IDictionary<string, string> queryString)
        {
            this.requestMessage.RequestUri = UrlBuilder.AppendQueryString(this.requestMessage.RequestUri, queryString);
            return this;
        }

        public TaskAwaiter<IResponse> GetAwaiter()
        {
           return this.SendAsync().GetAwaiter();
        }

        public async Task<T> ReadResponseAsync<T>()
        {
            throw new NotImplementedException();
        }

        private async Task<IResponse> SendAsync()
        {
            var httpResponse = await this.httpClient.SendAsync(this.requestMessage, HttpCompletionOption.ResponseHeadersRead,cancellationToken).ConfigureAwait(false);

            return new Response(httpResponse);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRequest WithCancellationToken(CancellationToken cancellationToken, Action cancelCallBack = null)
        {
            this.cancellationToken = cancellationToken;
            this.requestCancelCallBack = cancelCallBack;
            return this;
        }

        public IRequest WithValidStatusCode(IEnumerable<HttpStatusCode> statusCodeCollection)
        {
            this.validStatusCodes = statusCodeCollection;
            return this;
        }
    }
}
