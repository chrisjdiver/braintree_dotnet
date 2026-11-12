using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class UsBankAccountRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new UsBankAccountRequest
            {
                Token = "token-value",
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<token>token-value</token>", xml);
            TestHelper.AssertIncludes("<submit-for-settlement>true</submit-for-settlement>", xml);
        }
    }
}
