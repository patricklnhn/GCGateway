using System.Text;
using System.Web;
namespace JuntaClient
{
    public class ClientBase
    {
        public string baseurl = "https://legacy.flow.test.nhn.no/integration/";
        public byte[] byteArray { get; set; }

        /// <summary>
        /// Setting the HttpClient Base
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