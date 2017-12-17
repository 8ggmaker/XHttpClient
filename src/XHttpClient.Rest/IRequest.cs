using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XHttpClient.Rest
{
    public interface IRequest:IDisposable
    {
        IRequest WithBearerAuthentication(string token);

        IRequest WithAuthentication(string key, string value);

        IRequest WithHeaders(IDictionary<string, string> headers);

        IRequest WithQueryString(IDictionary<string, string> queryStrings);

        IRequest WithContentType(string type);


        IRequest WithContent(HttpContent content);

        Task<T> ReadResponseAsync<T>();
    }
}
