using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class ClientTokenOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new ClientTokenOptionsRequest
            {
                FailOnDuplicatePaymentMethod = true,
                FailOnDuplicatePaymentMethodForCustomer = true,
                MakeDefault = true,
                VerifyCard = true
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<fail-on-duplicate-payment-method>true</fail-on-duplicate-payment-method>", xml);
            TestHelper.AssertIncludes("<fail-on-duplicate-payment-method-for-customer>true</fail-on-duplicate-payment-method-for-customer>", xml);
            TestHelper.AssertIncludes("<make-default>true</make-default>", xml);
            TestHelper.AssertIncludes("<verify-card>true</verify-card>", xml);
        }
    }
}
