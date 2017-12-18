using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHttpClient.Rest;

namespace XHttpClient.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.microsoft.com";

            var res = url.ToRestable()
                .GetRequest("GET")
                .ReadResponseAsync<string>().Result;
        }
    }
}
