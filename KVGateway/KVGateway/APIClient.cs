using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Newtonsoft.Json.Linq;

namespace KVClient
{
    /// <summary>
    /// HttpClient for Kartverket's Addresse API
    /// </summary>
    public class APIClient : ClientBase
    {
        /// <summary>
        /// As this function is used to populate
        /// autocomplete controls, set the 
        /// hitsPerPage parameter to a high number 50 or 60
        /// There's an astriks as a wild card added after the search string 
        /// </summary>
        /// <param name="search"></param>
        /// <param name="hitsPerPage"></param>
        /// <returns>List of strings</returns>
        public List<string> GetAddresses(string search, int? hitsPerPage)
        {
            List<string> addresses = new List<string>();
            baseurl += search + "*"; 
            if(hitsPerPage == null ||hitsPerPage.Value == 0 )
            {
                hitsPerPage = 100;
            }
            baseurl+= "&treffPerSide=" + hitsPerPage.Value.ToString();
            try
            {

            
            var client = HttpClient(baseurl);
            var response = client.GetAsync(baseurl).Result;
            var str = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                { 
                    //TODO Add logging
                    return addresses;
                }
                    
            JObject joResponse = JObject.Parse(str);
            var adresser = from r in joResponse["adresser"]
                           select new tmpAddress { addrText = r["adressetekst"].ToString(), pNr = r["postnummer"].ToString(), pSted = r["poststed"].ToString() };

            foreach (var a in adresser)
            {
                addresses.Add(a.ToString());
            }
            }
            catch (Exception ex)
            {
                //TODO Error handling
                string err = ex.InnerException.Message;
            }
            return addresses;
        }

        /// <summary>
        /// For testing that the url is correct
        /// and service is up.
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Http Response Message</returns>
        public HttpResponseMessage TestUrl(string search)
        {
            List<string> addresses = new List<string>();
            baseurl += search + "*";
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                var client = HttpClient(baseurl);
                response = client.GetAsync(baseurl).Result;
                var str = response.Content.ReadAsStringAsync().Result;
            }
            catch
            {
                return response;
            }
            return response;
        }
         
    }
}
