using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class CreditCardVerificationOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new CreditCardVerificationOptionsRequest
            {
                Amount = "9.99",
                MerchantAccountId = "merchant-account-id",
                AccountType = "credit",
                AccountInformationInquiry = "send_data"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<amount>9.99</amount>", xml);
            TestHelper.AssertIncludes("<merchant-account-id>merchant-account-id</merchant-account-id>", xml);
            TestHelper.AssertIncludes("<account-type>credit</account-type>", xml);
            TestHelper.AssertIncludes("<account-information-inquiry>send_data</account-information-inquiry>", xml);
        }
    }
}
