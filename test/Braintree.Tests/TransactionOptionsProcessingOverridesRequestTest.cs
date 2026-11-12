using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionOptionsProcessingOverridesRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionOptionsProcessingOverridesRequest
            {
                CustomerEmail = "customer@example.com",
                CustomerFirstName = "First",
                CustomerLastName = "Last",
                CustomerTaxIdentifier = "tax-id-value"
            };

            string xml = request.ToXml("processing-overrides");

            TestHelper.AssertIncludes("<customer-email>customer@example.com</customer-email>", xml);
            TestHelper.AssertIncludes("<customer-first-name>First</customer-first-name>", xml);
            TestHelper.AssertIncludes("<customer-last-name>Last</customer-last-name>", xml);
            TestHelper.AssertIncludes("<customer-tax-identifier>tax-id-value</customer-tax-identifier>", xml);
        }
    }
}
