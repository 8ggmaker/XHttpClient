using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using XHttpClient.Internal;

namespace XHttpClient
{
    public class HttpClientManager: IDisposable
    {
        private static ConcurrentDictionary<Uri, ServiceEndPointInfo> servicePointStore = new ConcurrentDictionary<Uri, ServiceEndPointInfo>();

        private static int defaultConnectionLeaseTimeout =  10 * 1000;

        private HttpClientHandler defaultHttpClientHandler;
        
        public HttpClientManager()
        {
            defaultHttpClientHandler = new HttpClientHandler();
        }

        public IHttpClient GetHttpClient(string requestUri)
        {
            DefaultHttpClient httpClient = new DefaultHttpClient(defaultHttpClientHandler, false)
            {
                BaseAddress = new Uri(requestUri)
            };
            return httpClient;
        }

        public IHttpClient GetHttpClient(Uri requestUri)
        {
            DefaultHttpClient httpClient = new DefaultHttpClient(defaultHttpClientHandler, false)
            {
                BaseAddress = requestUri
            };
            return httpClient;
        }

        public IHttpClient GetHttpClient(string requestUri, int connectionLimit)
        {
            Uri uri = new Uri(requestUri);
            SetNewConnectionLimit(uri, connectionLimit);
            DefaultHttpClient httpClient = new DefaultHttpClient(defaultHttpClientHandler, false)
            {
                BaseAddress = uri
            };
            return httpClient;
        }

        public IHttpClient GetHttpClient(Uri requestUri, int connectionLimit)
        {
            SetNewConnectionLimit(requestUri, connectionLimit);
            DefaultHttpClient httpClient = new DefaultHttpClient(defaultHttpClientHandler, false)
            {
                BaseAddress = requestUri
            };
            return httpClient;
        }

        private static void SetNewConnectionLimit(Uri uri, int newConnectionLimit)
        {

            servicePointStore.AddOrUpdate(uri, AddServiceEndPointInfo, UpdateServiceEndPointInfo(newConnectionLimit));
        }

        private static Func<Uri, ServiceEndPointInfo> AddServiceEndPointInfo
        {
            get
            {
                return key =>
                {
                    ServicePoint sp = ServicePointManager.FindServicePoint(key);
                    sp.ConnectionLeaseTimeout = defaultConnectionLeaseTimeout;
                    return new ServiceEndPointInfo
                    {
                        ConnectionLimit = sp.ConnectionLimit,
                        ConnectionLeaseTimeOut = defaultConnectionLeaseTimeout,
                        Uri = key
                    };
                };
            }
        }

        private static Func<Uri,ServiceEndPointInfo,ServiceEndPointInfo> UpdateServiceEndPointInfo(int newConnectionLimit)
        {
            return (key, oldVal) =>
            {
                oldVal.ConnectionLimit = Math.Max(oldVal.ConnectionLimit, newConnectionLimit);
               
                var sp = ServicePointManager.FindServicePoint(key);
                sp.ConnectionLimit = oldVal.ConnectionLimit;
                return oldVal;
            };
        }

        public void Dispose()
        {
            if (defaultHttpClientHandler != null)
            {
                defaultHttpClientHandler.Dispose();
                defaultHttpClientHandler = null;
            }

        }
    }
}
