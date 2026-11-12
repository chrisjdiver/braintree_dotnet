using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class MerchantAccountRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new MerchantAccountRequest
            {
                Id = "my-merchant-account-id"
            };

            string xml = request.ToXml();

            Assert.AreEqual("<merchant-account><id>my-merchant-account-id</id></merchant-account>", xml);
        }
    }
}
