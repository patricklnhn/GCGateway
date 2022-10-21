using System.Text;
using System.Web;

namespace GCClient
{
    /// <summary>
    /// Base class for HttpClient
    /// set up for searches in GlobalConnect API's
    /// UserKey, Username/password and base URL will be moved at a later point
    /// </summary>
    public class ClientBase
    {
        public string baseurl = "https://api-2445582745966.production.gw.apicast.io/1.0/";
        internal string userKey = "9f1ce36c5b3986988941ad047465e049";
        internal byte[] byteArray = Encoding.ASCII.GetBytes("nhntest:gctest00");

        /// <summary>
        /// Sets URL with userkey and base URL
        /// </summary>
        /// <returns></returns>
        public string Url()
        {
            var builder = new UriBuilder(baseurl);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["USER_KEY"] = $"{userKey}";

            builder.Query = query.ToString();
            var url = builder.ToString();
            return url;
        }

        /// <summary>
        /// Sets the HttpClient
        /// with base url and Authentication header
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HttpClient HttpClient(string url)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            return client;
        }

    }
}