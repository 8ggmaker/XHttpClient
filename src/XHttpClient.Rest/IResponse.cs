using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XHttpClient.Rest
{
    public interface IResponse:IDisposable
    {
        Task<T> ReadResponseAs<T>();
    }
}
