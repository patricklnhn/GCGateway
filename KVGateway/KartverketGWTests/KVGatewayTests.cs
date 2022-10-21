using KVClient;

namespace KartverketGWTests
{
    public class Tests
    {
        private APIClient client;
        [SetUp]
        public void Setup()
        {
            client = new APIClient();
        }
        
        [Test]
        public void TestAddressesAPI()
        {
            string search = "Verkstedveien 1";
            var strRet = client.GetAddresses(search, 100);
            Assert.IsNotNull(strRet);          
        }

        [Test]
        public void TestAddressesNumberOfReturns()
        {
            string search = "Verkstedveien 1";
            var strRet = client.GetAddresses(search, 100);
            Assert.IsTrue(strRet.Count >= 1);
            

        }

        [Test]
        public void IsServiceURLCorrectAndUP()
        {
            string search = "Verkstedveien 1";
            var strRet = client.TestUrl(search);
            Assert.IsTrue(strRet.IsSuccessStatusCode);
        }
    }
}