using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GCGateway.Controllers
{
    //TODO add MSAL Authentication


    /// <summary>
    /// Gateway API for getting addresses from GlobalConnect
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalConnectAddressController : ControllerBase
    {
        private readonly ILogger _logger;

        public GlobalConnectAddressController(ILogger<GlobalConnectAddressController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get method for address from GlobalConnect 
        /// Search string is comma separated(Verkstedveien 1, 0277, OSLO)
        /// And is programatically invoked from the initial search
        /// from Kartverket
        /// </summary>
        /// <param name="searchstring"></param>
        /// <returns>HTTP response message with content of address(es)</returns>
        [HttpGet(Name = "GetAddress")]
        public HttpResponseMessage Get(string searchstring)
        {
            
            APIClient client = new APIClient();
            string url = "address/" + searchstring;
            var strRet = client.GetAddressGabIdFromGC(url).ToString();
            var content = new StringContent(
                        strRet,
                        Encoding.UTF8,
                        "application/text"
                    );
            return new HttpResponseMessage()
            {
                Content = content
            };
        }
    }
}
