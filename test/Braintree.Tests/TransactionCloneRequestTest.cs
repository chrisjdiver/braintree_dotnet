using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionCloneRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionCloneRequest
            {
                Amount = 9.99M,
                Channel = "v",
                Options = new TransactionOptionsCloneRequest
                {
                    SubmitForSettlement = true
                }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<amount>9.99</amount>", xml);
            TestHelper.AssertIncludes("<channel>v</channel>", xml);
            TestHelper.AssertIncludes("<submit-for-settlement>true</submit-for-settlement>", xml);
        }
    }
}
