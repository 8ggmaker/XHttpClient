using System;
using System.Collections.Generic;
using System.Text;
using XHttpClient.Rest.Internal;

namespace XHttpClient.Rest
{
    public static class StringRestableExtension
    {
        public static IRestable ToRestable(this string str)
        {
            return new DefaultRestable(str);
        }
    }
}
