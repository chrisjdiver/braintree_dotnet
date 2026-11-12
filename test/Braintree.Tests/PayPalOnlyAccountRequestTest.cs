using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PayPalOnlyAccountRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PayPalOnlyAccountRequest
            {
                ClientId = "some-client-id",
                ClientSecret = "some-client-secret"
            };

            string xml = request.ToXml("paypal");

            TestHelper.AssertIncludes("<client_id>some-client-id</client_id>", xml);
            TestHelper.AssertIncludes("<client_secret>some-client-secret</client_secret>", xml);
        }
    }
}
