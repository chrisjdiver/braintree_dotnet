using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionOptionsAmexRewardsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionOptionsAmexRewardsRequest
            {
                RequestId = "v",
                Points = "v",
                CurrencyAmount = "v",
                CurrencyIsoCode = "v"
            };

            string xml = request.ToXml("amex-rewards");

            TestHelper.AssertIncludes("<request-id>v</request-id>", xml);
            TestHelper.AssertIncludes("<points>v</points>", xml);
            TestHelper.AssertIncludes("<currency-amount>v</currency-amount>", xml);
            TestHelper.AssertIncludes("<currency-iso-code>v</currency-iso-code>", xml);
        }

        [Test]
        public void ToQueryString_IncludesAllData()
        {
            var request = new TransactionOptionsAmexRewardsRequest
            {
                RequestId = "v",
                Points = "v",
                CurrencyAmount = "v",
                CurrencyIsoCode = "v"
            };

            string queryString = request.ToQueryString("amex-rewards");

            TestHelper.AssertIncludes("amex_rewards%5Brequest_id%5D=v", queryString);
            TestHelper.AssertIncludes("amex_rewards%5Bpoints%5D=v", queryString);
            TestHelper.AssertIncludes("amex_rewards%5Bcurrency_amount%5D=v", queryString);
            TestHelper.AssertIncludes("amex_rewards%5Bcurrency_iso_code%5D=v", queryString);
        }
    }
}
