using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionPayPalRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionPayPalRequest
            {
                PayeeId = "payee-id-value",
                PayeeEmail = "payee@example.com",
                PayerId = "payer-id-value",
                PaymentId = "payment-id-value"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<payee-id>payee-id-value</payee-id>", xml);
            TestHelper.AssertIncludes("<payee-email>payee@example.com</payee-email>", xml);
            TestHelper.AssertIncludes("<payer-id>payer-id-value</payer-id>", xml);
            TestHelper.AssertIncludes("<payment-id>payment-id-value</payment-id>", xml);
        }
    }
}
