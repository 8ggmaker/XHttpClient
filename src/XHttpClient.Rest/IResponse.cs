using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace XHttpClient.Rest
{
    public interface IResponse:IDisposable
    {
        Task<T> ReadAsAsync<T>();

        Task<string> ReadAsStringAsync();

        Task<byte[]> ReadAsByteArrayAsync();

        Task<Stream> ReadAsStreamAsync();
    }
}
