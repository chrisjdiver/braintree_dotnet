using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionSubMerchantRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionSubMerchantRequest
            {
                Address = new AddressRequest
                {
                    StreetAddress = "123 Main St",
                    Locality = "Chicago"
                },
                LegalName = "Legal Name",
                ReferenceNumber = "reference-number-value",
                TaxId = "tax-id-value"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<street-address>123 Main St</street-address>", xml);
            TestHelper.AssertIncludes("<locality>Chicago</locality>", xml);
            TestHelper.AssertIncludes("<legal-name>Legal Name</legal-name>", xml);
            TestHelper.AssertIncludes("<reference-number>reference-number-value</reference-number>", xml);
            TestHelper.AssertIncludes("<tax-id>tax-id-value</tax-id>", xml);
        }
    }
}
