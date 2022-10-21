using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GCGateway.Controllers
{
    //TODO add MSAL Authentication


    /// <summary>
    /// Gateway API for getting coverage info from GlobalConnect
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalConnectCoverageController : ControllerBase
    {
        private readonly ILogger _logger;

        public GlobalConnectCoverageController(ILogger<GlobalConnectCoverageController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// API for getting coverage information for a given address
        /// and a given product. The product to search for to see 
        /// if there is a fiber in place is "IPVPN Fiber".
        /// The gabId is the Id for the address found in address search
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetCoverage")]
        public async Task<HttpResponseMessage> Get(int custId, string articleGroupName, int gabId)
        {
            
            APIClient client = new APIClient();
            var retJson = await client.GetCoverageFromGC("coverage/articles/", custId, articleGroupName, gabId);
            var content = new StringContent(
                        retJson,
                        Encoding.UTF8,
                        "application/json"
                    );
            return new HttpResponseMessage()
            {
                Content = content
            };
        }
    }

}

