using System;
using System.Collections.Generic;
using System.Text;

namespace XHttpClient.Exception
{
    public class Error
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public IDictionary<string, object> Data { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
