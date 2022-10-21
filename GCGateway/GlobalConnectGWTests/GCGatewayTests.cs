namespace GlobalConnectGWTests
{
    public class GCGatewayTests
    {
        /// <summary>
        /// 
        /// </summary>
        private APIClient client;
        [SetUp]

        /// <summary>
        /// Set up APIClient for all tests
        /// </summary>
        public void Setup()
        {
            client = new APIClient();
        }

        [Test]
        public void TestAddressAPI()
        {           
            string url = "address/Verkstedveien 1, 0277, OSLO";
            var strRet = client.GetAddressGabIdFromGC(url).ToString();
            var content = new StringContent(
                        strRet,
                        Encoding.UTF8,
                        "application/text"
                    );
            var result = new HttpResponseMessage()
            {
                Content = content
            };
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        
        [Test]
       public async Task TestContentAPI()
        {           
            string articleGroupName = "IPVPN Fiber";
            int fromAddressGabId = 285839645;
            int custId = 201834;

            var retJson = await client.GetCoverageFromGC("coverage/articles/", custId, articleGroupName, fromAddressGabId);
            var content = new StringContent(
                        retJson,
                        Encoding.UTF8,
                        "application/json"
                    );
            var result = new HttpResponseMessage()
            {
                Content = content
            };
            Assert.IsTrue(result.IsSuccessStatusCode);
        }
    }
}