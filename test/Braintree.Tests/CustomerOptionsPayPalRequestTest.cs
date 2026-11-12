using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class CustomerOptionsPayPalRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new CustomerOptionsPayPalRequest
            {
                PayeeEmail = "payee@example.com",
                OrderId = "order-id",
                CustomField = "custom-field",
                Description = "description",
                Amount = 9.99M
            };

            string xml = request.ToXml("paypal");

            TestHelper.AssertIncludes("<payee-email>payee@example.com</payee-email>", xml);
            TestHelper.AssertIncludes("<order-id>order-id</order-id>", xml);
            TestHelper.AssertIncludes("<custom-field>custom-field</custom-field>", xml);
            TestHelper.AssertIncludes("<description>description</description>", xml);
            TestHelper.AssertIncludes("<amount>9.99</amount>", xml);
        }
    }
}
