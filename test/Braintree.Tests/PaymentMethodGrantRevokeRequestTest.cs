using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodGrantRevokeRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PaymentMethodGrantRevokeRequest
            {
                SharedPaymentMethodToken = "some-token"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<shared-payment-method-token>some-token</shared-payment-method-token>", xml);
        }
    }
}
