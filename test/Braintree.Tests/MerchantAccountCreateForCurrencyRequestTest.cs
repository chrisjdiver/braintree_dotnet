using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class MerchantAccountCreateForCurrencyRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new MerchantAccountCreateForCurrencyRequest
            {
                Currency = "USD",
                Id = "my-merchant-account-id"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<currency>USD</currency>", xml);
            TestHelper.AssertIncludes("<id>my-merchant-account-id</id>", xml);
        }
    }
}
