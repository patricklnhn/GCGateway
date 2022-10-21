using GCClient;
using Nancy.Json;
using System.Text;
using Newtonsoft.Json.Linq;
namespace GCGateway
{
    /// <summary>
    /// HttpClient for Communication with GlobalConnects API
    /// </summary>
    public class APIClient: ClientBase
    {
        /// <summary>
        /// Method to get coverage information from GlobalConnects API 
        /// </summary>
        /// <param name="urlPart"></param>
        /// <param name="articleGroupName"></param>
        /// <param name="gabId"></param>
        /// <returns>Returns json with coverage and price info</returns>
        public async Task<string> GetCoverageFromGC(string urlPart, int custId, string articleGroupName, int gabId)
        {
            baseurl += urlPart + custId;
            var url = Url();
            var client = HttpClient(baseurl);

            var model = new CoverageSearchRequest();
            model.articleGroupName = articleGroupName;
            model.fromAddressGabId = gabId;

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(model);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, stringContent);
                var result = await response.Content.ReadAsStringAsync();

                JObject joResponse = JObject.Parse(result);
                return joResponse.ToString();
            }
            catch (HttpRequestException httpReqEx)
            {
                //TODO Add logging
                string err = httpReqEx.InnerException.ToString();
            }

            return  String.Empty;

        }
        /// <summary>
        /// Method to get GabId for use in coverage call
        /// </summary>
        /// <param name="bUrl"></param>
        /// <returns>GabId</returns>
        public int GetAddressGabIdFromGC(string urlPart)
        {
            baseurl += urlPart;
            var url = Url();
            var client = HttpClient(baseurl);
            try
            {
                var response = client.GetAsync(url).Result;
                string str = response.Content.ReadAsStringAsync().Result.ToString();
                var subStr = str.Substring(1, str.Length - 2);
                JObject joResponse = JObject.Parse(subStr);
                var adresser = from r in joResponse["gabId"].ToString()
                               select r;
                string strgabid = "";
                foreach (var c in adresser)
                {
                    strgabid += c.ToString();

                }
                int gabid = 0;
                int.TryParse(strgabid, out gabid);
                return gabid;
            }
            catch(HttpRequestException httpReqEx)
            {
                string err = httpReqEx.InnerException.ToString();
            }
            return -1;
            
        }
    }
}
