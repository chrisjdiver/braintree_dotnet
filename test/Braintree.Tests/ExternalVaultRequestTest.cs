using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class ExternalVaultRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new ExternalVaultRequest
            {
                Status = "will_vault",
                PreviousNetworkTransactionId = "1234"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<external-vault>", xml);
            TestHelper.AssertIncludes("<status>will_vault</status>", xml);
            TestHelper.AssertIncludes("<previous-network-transaction-id>1234</previous-network-transaction-id>", xml);
        }

        [Test]
        public void ToQueryString_IncludesAllData()
        {
            var request = new ExternalVaultRequest
            {
                Status = "will_vault",
                PreviousNetworkTransactionId = "1234"
            };

            string queryString = request.ToQueryString();

            TestHelper.AssertIncludes("external_vault%5Bstatus%5D=will_vault", queryString);
            TestHelper.AssertIncludes("external_vault%5Bprevious_network_transaction_id%5D=1234", queryString);
        }
    }
}
