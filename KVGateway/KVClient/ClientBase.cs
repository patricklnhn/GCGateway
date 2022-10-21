using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVClient
{
    /// <summary>
    /// The base for HttpClient
    /// </summary>
    public class ClientBase
    {
        public string baseurl = "https://ws.geonorge.no/adresser/v1/sok?adressetekst=";

        /// <summary>
        /// Setting the HttpClient Base
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HttpClient HttpClient(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            return client;
        }
    }
}
