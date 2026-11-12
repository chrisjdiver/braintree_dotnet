using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodGrantRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PaymentMethodGrantRequest
            {
                AllowVaulting = true,
                IncludeBillingPostalCode = true,
                RevokeAfter = "2030-01-01"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<allow-vaulting>true</allow-vaulting>", xml);
            TestHelper.AssertIncludes("<include-billing-postal-code>true</include-billing-postal-code>", xml);
            TestHelper.AssertIncludes("<revoke-after>2030-01-01</revoke-after>", xml);
        }
    }
}
