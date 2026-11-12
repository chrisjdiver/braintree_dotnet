using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class SubscriptionOptionsPayPalRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new SubscriptionOptionsPayPalRequest
            {
                Description = "v"
            };

            string xml = request.ToXml("paypal");

            TestHelper.AssertIncludes("<description>v</description>", xml);
        }
    }
}
