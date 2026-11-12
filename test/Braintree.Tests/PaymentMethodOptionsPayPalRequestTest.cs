using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodOptionsPayPalRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PaymentMethodOptionsPayPalRequest
            {
                PayeeEmail = "payee@example.com",
                OrderId = "some-order-id",
                CustomField = "some-custom-field",
                Description = "some-description",
                Amount = 9.99M,
                Shipping = new AddressRequest
                {
                    FirstName = "Jane"
                }
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<payee-email>payee@example.com</payee-email>", xml);
            TestHelper.AssertIncludes("<order-id>some-order-id</order-id>", xml);
            TestHelper.AssertIncludes("<custom-field>some-custom-field</custom-field>", xml);
            TestHelper.AssertIncludes("<description>some-description</description>", xml);
            TestHelper.AssertIncludes("<amount>9.99</amount>", xml);
            TestHelper.AssertIncludes("<shipping>", xml);
            TestHelper.AssertIncludes("<first-name>Jane</first-name>", xml);
        }
    }
}
