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
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Code))
            {
                sb.Append($" Code:{Code}");
            }

            if (!string.IsNullOrWhiteSpace(Message))
            {
                sb.Append($" Message:{Message}");
            }

            return sb.ToString();
        }
    }

    public enum ErrorCode
    {
        ArgsNullException = 1,
        InvalidRequest,

    }
}
