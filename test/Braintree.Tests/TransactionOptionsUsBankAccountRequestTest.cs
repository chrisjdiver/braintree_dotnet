using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionOptionsUsBankAccountRequestTest
    {
        [Test]
        public void ToXml_IncludesAchType()
        {
            var request = new TransactionOptionsUsBankAccountRequest()
            {
                AchType = "standard"
            };

            string xml = request.ToXml("us-bank-account");
            TestHelper.AssertIncludes("<ach-type>standard</ach-type>", xml);
        }

        [Test]
        public void ToXml_ExcludesAchTypeWhenNull()
        {
            var request = new TransactionOptionsUsBankAccountRequest()
            {
                AchType = null
            };

            string xml = request.ToXml("us-bank-account");
            Assert.IsFalse(xml.Contains("<ach-type>"));
        }

        [Test]
        public void ToQueryString_IncludesAchType()
        {
            var request = new TransactionOptionsUsBankAccountRequest()
            {
                AchType = "standard"
            };

            string queryString = request.ToQueryString("us-bank-account");
            TestHelper.AssertIncludes("us_bank_account%5Bach_type%5D=standard", queryString);
        }
    }
}

