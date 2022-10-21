using JuntaGateway;
namespace JuntaGWTests
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
        public void TestGetPopsFromAddress()
        {
            string address = "Sykehusveien";
            string zip = "9019";
            int streetNo = 23;
            var strRet = client.GetPopsFromJuntaOnAddress(address, streetNo, zip);
            Assert.IsTrue(strRet.Length > 2);
        }

        [Test]
        public void TestGetPops()
        {     
            var PopProxy = client.GetPops();
            //Assert.IsTrue(strRet.Length > 2);
            Assert.IsNotNull(PopProxy);
        }



        [Test]
        public void TestGetContacts()
        {
            var strRet = client.GetContacts("espen");
            Assert.IsTrue(strRet.Length > 2);
        }
    }
}