using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class UsBankAccountVerificationConfirmRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new UsBankAccountVerificationConfirmRequest
            {
                DepositAmounts = new int[] { 17, 29 }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<deposit-amounts type=\"array\"><item>17</item><item>29</item></deposit-amounts>", xml);
        }
    }
}
