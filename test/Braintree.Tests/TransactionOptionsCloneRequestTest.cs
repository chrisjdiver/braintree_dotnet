using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionOptionsCloneRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionOptionsCloneRequest
            {
                SubmitForSettlement = true
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<submit-for-settlement>true</submit-for-settlement>", xml);
        }

        [Test]
        public void ToQueryString_IncludesAllData()
        {
            var request = new TransactionOptionsCloneRequest
            {
                SubmitForSettlement = true
            };

            string queryString = request.ToQueryString("options");

            TestHelper.AssertIncludes("options%5Bsubmit_for_settlement%5D=true", queryString);
        }
    }
}
