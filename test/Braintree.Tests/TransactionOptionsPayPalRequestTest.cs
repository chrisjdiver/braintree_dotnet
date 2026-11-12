using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionOptionsPayPalRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionOptionsPayPalRequest
            {
                CustomField = "custom value",
                Description = "a description",
                PayeeId = "payee-id-value",
                PayeeEmail = "payee@example.com"
            };
            request.SupplementaryData.Add("key", "value");

            string xml = request.ToXml("paypal");

            TestHelper.AssertIncludes("<custom-field>custom value</custom-field>", xml);
            TestHelper.AssertIncludes("<description>a description</description>", xml);
            TestHelper.AssertIncludes("<payee-id>payee-id-value</payee-id>", xml);
            TestHelper.AssertIncludes("<payee-email>payee@example.com</payee-email>", xml);
            TestHelper.AssertIncludes("<supplementary-data><key>value</key></supplementary-data>", xml);
        }
    }
}
