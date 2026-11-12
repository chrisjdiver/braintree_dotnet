using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class SubscriptionTransactionOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new SubscriptionTransactionOptionsRequest
            {
                SubmitForSettlement = true
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<submit-for-settlement>true</submit-for-settlement>", xml);
        }
    }
}
