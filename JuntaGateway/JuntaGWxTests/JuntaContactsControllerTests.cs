using JuntaGateway;
using JuntaGateway.Controllers;
using Microsoft.Extensions.Logging;

namespace JuntaGWxTests
{
    
    //private APIClient client;
    public class JuntaContactsControllerTests
    {
        //private readonly ILogger _logger;
        public JuntaContactsControllerTests()
        {
            //client = new APIClient();
            //_logger = logger;
        }
        [Fact]
        public async Task TestControllerMultipleContacts()
        {
            JuntaGateway.Controllers.JuntaContactsController obj = new JuntaGateway.Controllers.JuntaContactsController();
            var ret = await obj.GetContacts("11425, 11426", 1);
            var res = ret.Content.ReadAsStringAsync();
            if (res.IsCompletedSuccessfully)
            {
                var content = res.Result.ToString();
            }
            Assert.True(res.IsCompletedSuccessfully);

        }

        [Fact]
        public async Task TestControllerSingleContact()
        {
            JuntaGateway.Controllers.JuntaContactsController obj = new JuntaGateway.Controllers.JuntaContactsController();
            var ret = await obj.GetContacts("11425", 1);
            var res = ret.Content.ReadAsStringAsync();
            if (res.IsCompletedSuccessfully)
            {
                var content = res.Result.ToString();
            }
            Assert.True(res.IsCompletedSuccessfully);

        }
    }
}
