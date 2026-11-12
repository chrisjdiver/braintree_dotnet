using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentFacilitatorRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PaymentFacilitatorRequest
            {
                PaymentFacilitatorId = "4321",
                SubMerchant = new TransactionSubMerchantRequest
                {
                    LegalName = "Sub Tony Stark",
                    ReferenceNumber = "123456789012345",
                    TaxId = "ACSD1234567890"
                }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<payment-facilitator>", xml);
            TestHelper.AssertIncludes("<payment-facilitator-id>4321</payment-facilitator-id>", xml);
            TestHelper.AssertIncludes("<sub-merchant>", xml);
            TestHelper.AssertIncludes("<legal-name>Sub Tony Stark</legal-name>", xml);
            TestHelper.AssertIncludes("<reference-number>123456789012345</reference-number>", xml);
            TestHelper.AssertIncludes("<tax-id>ACSD1234567890</tax-id>", xml);
        }
    }
}
