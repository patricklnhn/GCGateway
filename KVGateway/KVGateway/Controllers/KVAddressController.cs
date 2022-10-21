using KVClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KVGateway.Controllers
{
    /// <summary>
    /// Gateway API for communications with Kartverket 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class KVAddressController : ControllerBase
    {
        //private readonly ILogger _logger;

        //public KVAddressController(ILogger<KVAddressController> logger)
        //{
        //    _logger = logger;
        //}

        /// <summary>
        /// API for addresses form Kartverket.
        /// Return from kartverket is list of addresses(being casted to tmpAddresses)
        /// consisting of street name and number, zip code, city/place
        /// The return is in the html body for the least amount of overhead.
        /// </summary>
        /// <param name="searchstring">Street name</param>
        /// <param name="hitsperPage">Maximum number of hits</param>
        /// <returns>List of addresses</returns>

        //TODO add MSAL Authentication



        [HttpGet(Name = "GetAddress")]
        public List<string> Get(string searchstring, int? hitsperPage)
        {
            APIClient client = new APIClient();
            return client.GetAddresses(searchstring, hitsperPage);
        }
    }
    //NOTE Service will return empty body in html return if no address is found
}
