using System;
using System.Collections.Generic;
using System.Text;

namespace XHttpClient
{
    internal struct ServiceEndPointInfo
    {
        /// <summary>
        /// Host Name of URL
        /// </summary>
        internal Uri Uri { get; set; }

        /// <summary>
        /// TCP Connection Limit of Current EndPoint
        /// </summary>
        internal int ConnectionLimit { get; set; }

        /// <summary>
        /// TimeOut to Release idle Connection, minutes
        /// </summary>
        internal int ConnectionLeaseTimeOut { get; set; }
    }
}
