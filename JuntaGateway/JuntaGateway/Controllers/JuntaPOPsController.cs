using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using JuntaClient;

namespace JuntaGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuntaPOPsController : ControllerBase
    {
        private readonly ILogger<APIClient> _logger;

        public JuntaPOPsController(ILogger<APIClient> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "GetPOPs")]
        public async Task<HttpResponseMessage> Get(string streetname, int streetNo, string zip)
        {
            APIClient client = new APIClient();
            string url = "address/streename=" + streetname +"&streetNo="+ streetNo + "&zip="+ zip;
            var strRet = await client.GetPopsFromJuntaOnAddress(streetname, streetNo, zip);
            var content = JsonContent.Create(strRet);

            return new HttpResponseMessage()
            {
                Content = content
            };
        }
    }
}
