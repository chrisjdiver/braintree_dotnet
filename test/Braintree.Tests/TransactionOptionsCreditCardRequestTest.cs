using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionOptionsCreditCardRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionOptionsCreditCardRequest
            {
                AccountType = "v",
                ProcessDebitAsCredit = true
            };

            string xml = request.ToXml("credit-card");

            TestHelper.AssertIncludes("<account-type>v</account-type>", xml);
            TestHelper.AssertIncludes("<process-debit-as-credit>true</process-debit-as-credit>", xml);
        }

        [Test]
        public void ToQueryString_IncludesAllData()
        {
            var request = new TransactionOptionsCreditCardRequest
            {
                AccountType = "v",
                ProcessDebitAsCredit = true
            };

            string queryString = request.ToQueryString("credit-card");

            TestHelper.AssertIncludes("credit_card%5Baccount_type%5D=v", queryString);
            TestHelper.AssertIncludes("credit_card%5Bprocess_debit_as_credit%5D=true", queryString);
        }
    }
}
