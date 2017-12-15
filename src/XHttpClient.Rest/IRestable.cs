using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientManager.Rest
{
    public interface IRestable
    {

        Task<T> GetAsync<T>();

        Task<T> PostAsync<T>();

        Task<T> SendAsync<T>();

    }


}
