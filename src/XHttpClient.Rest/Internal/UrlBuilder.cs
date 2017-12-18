using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHttpClient.Rest.Internal
{
    internal static class UrlBuilder
    {
        internal static Uri AppendQueryString(Uri uri, IDictionary<string,string> queryString)
        {
            if (uri == null||queryString==null||queryString.Count==0)
            {
                return uri;
            }

            string querystr = string.Join("&",queryString.Select(keyval=>$"{keyval.Key}={keyval.Value}"));
            StringBuilder uriBuilder = new StringBuilder(uri.AbsoluteUri);

            if (string.IsNullOrWhiteSpace(uri.Query)&&uriBuilder[uriBuilder.Length-1]!='?')
            {
                uriBuilder.Append("?");
            }
            else if(uriBuilder[uriBuilder.Length-1]!='&')
            {
                uriBuilder.Append("&");
            }

            uriBuilder.Append(querystr);

            return new Uri(uriBuilder.ToString());
            
        }
    }
}
