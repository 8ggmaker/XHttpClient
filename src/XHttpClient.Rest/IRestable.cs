using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XHttpClient.Rest
{
    public interface IRestable
    {
        IRequest GetRequest(string method);
    }


}
