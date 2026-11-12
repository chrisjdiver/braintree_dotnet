using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class CustomerOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new CustomerOptionsRequest
            {
                OptionsPayPal = new CustomerOptionsPayPalRequest
                {
                    PayeeEmail = "payee@example.com",
                    OrderId = "order-id",
                    Amount = 9.99M
                }
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<paypal>", xml);
            TestHelper.AssertIncludes("<payee-email>payee@example.com</payee-email>", xml);
            TestHelper.AssertIncludes("<order-id>order-id</order-id>", xml);
        }
    }
}
