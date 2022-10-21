using JuntaGateway;
using JuntaClient;
using Microsoft.Extensions.Logging;

namespace JuntaGWxTests
{
    public class JuntaTests
    {
        //private readonly ILogger<APIClient> _logger;
        private APIClient client;
        //public JuntaTests(ILogger<APIClient> logger)
        //{
        //    _logger = logger;
        //    client = new APIClient(_logger);
        //}

        public JuntaTests()
        {
            client = new APIClient();
        }
        [Fact]
        public async void TestGetPopsFromAddress()
        {
            string address = "Sykehusveien";
            string zip = "9019";
            int streetNo = 23;
            var ret = await client.GetPopsFromJuntaOnAddress(address, streetNo, zip);
            Assert.True(ret.Count > 0);
        }


        [Fact]
        public async void TestGetContact()
        {
            int id = 11426;
            var ret = await client.GetContact(id);
            Assert.True(ret.Count()==1);
        }

        [Fact]
        public async void GetListOfContacts()
        {
            int[] ids = new int[2] { 11425, 11426 };
            var ret = await client.GetListOfContacts(ids);
            Assert.True(ret.Count() == 2);
        }
        [Fact]
        public async void GetListOfContactsByEmail()
        {
            string mail = "lars.kjorholt@solsiden.nhn.no";
            var ret = await client.GetContactByEmail(mail);
            Assert.True(ret.Count() == 1);
        }

        [Fact]
        public async void GetListOfContactsByName()
        {
            string name = "Lars";
            var ret = await client.GetContactByName(name);
            Assert.True(ret.Count() >=1);
        }
    }
}