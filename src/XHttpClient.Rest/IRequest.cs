using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XHttpClient.Rest
{
    public interface IRequest:IDisposable
    {
        IRequest WithBearerAuthentication(string token);

        IRequest WithAuthentication(string key, string value);

        IRequest WithHeaders(IDictionary<string, string> headers);

        IRequest WithQueryString(IDictionary<string, string> queryString);

        IRequest WithContentType(string type);

        IRequest WithContent(HttpContent content);

        IRequest WithCancellationToken(CancellationToken cancellationToken, Action cancelCallBack = null);

        IRequest WithValidStatusCode(IEnumerable<HttpStatusCode> statusCodeCollection);

        Task<T> ReadResponseAsync<T>();

        TaskAwaiter<IResponse> GetAwaiter();

        
    }
}
