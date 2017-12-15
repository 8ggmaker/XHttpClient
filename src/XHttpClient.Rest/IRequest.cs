using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XHttpClient.Rest
{
    public interface IRequest:IDisposable
    {
        IRequest WithHeaders(IDictionary<string, string> headers);

        IRequest WithQueryString(IDictionary<string, string> queryStrings);

        IRequest WithContent(HttpContent content);

        Task<T> ReadResponse<T>();
    }
}
