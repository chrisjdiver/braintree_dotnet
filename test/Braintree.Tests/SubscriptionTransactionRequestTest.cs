using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class SubscriptionTransactionRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new SubscriptionTransactionRequest
            {
                Amount = 9.99M,
                SubscriptionId = "v",
                Options = new SubscriptionTransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<amount>9.99</amount>", xml);
            TestHelper.AssertIncludes("<subscription-id>v</subscription-id>", xml);
            TestHelper.AssertIncludes("<submit-for-settlement>true</submit-for-settlement>", xml);
            TestHelper.AssertIncludes("<type>sale</type>", xml);
        }
    }
}
