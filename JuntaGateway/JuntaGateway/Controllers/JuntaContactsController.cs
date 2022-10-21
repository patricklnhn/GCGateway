using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using JuntaClient;

namespace JuntaGateway.Controllers
{

    /// <summary>
    /// Junta Contacts
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    public class JuntaContactsController : ControllerBase
    {
        //private readonly ILogger _logger;

        public JuntaContactsController()
        {
            //ILogger<JuntaContactsController> logger
            //_logger = logger;
        }
        //private readonly ILogger _logger = new ILogger();;   
        /// <summary>
        /// Returns contacts from Junta
        /// </summary>
        /// <param name="search">Search parameter</param>
        /// <param name="iType">Use enum, email=0, ids=1, name=2</param>
        /// <returns>HttpResponseMessage</returns>
        /// <remarks>Remember to set up enum on caller side</remarks>
        [HttpGet(Name = "Get")]
        public async Task<HttpResponseMessage> GetContacts(string search, int iType)
        {
            

            //_logger.LogInformation("StartGetContacts");

            string url = "";
            List<ContactProxy> strRet = new List<ContactProxy>();
            APIClient client = new APIClient();
            //_logger.LogInformation("Set Client");
            switch (iType)
            {
                case 0:
                    //_logger.LogInformation("Case 0");
                    url = "flow_contacts/email=" + search;
                    strRet = await client.GetContactByEmail(search);
                    //_logger.LogInformation("Case 1 GetIsDone");
                    break;
                case 1:
                    //_logger.LogInformation("Case 1");
                    string[] ids = search.Split(",");
                    int[] aryInts = Array.ConvertAll(ids, s => int.Parse(s));
                    url = "flow_contacts/id=" + aryInts;
                    if(aryInts.Count() ==1)
                    {
                        //_logger.LogInformation("Case 1, single id");
                        strRet = await client.GetContact(aryInts[0]);
                        //_logger.LogInformation("Case 1 single id GetIsDone");
                    }
                    else
                    {
                        //_logger.LogInformation("Case 1, mulitiple id");
                        strRet = await client.GetListOfContacts(aryInts);
                        //_logger.LogInformation("Case 1 multiple id GetIsDone");
                    }
                       
                    
                    break;
                case 2:
                    //_logger.LogInformation("Case 2");
                    url = "flow_contacts/name=" + search;
                    strRet = await client.GetContactByName(search);
                    //_logger.LogInformation("Case 2 GetIsDone");
                    break;

            }
            var serializer = new Nancy.Json.JavaScriptSerializer();
            var json = serializer.Serialize(strRet);
            var content = JsonContent.Create(json);
            
            //_logger.LogInformation(strRet.ToString());
            return new HttpResponseMessage()
            {
                Content = content                
            };
        }
    }
}
