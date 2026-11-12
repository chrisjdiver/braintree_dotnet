using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PayPalAccountRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PayPalAccountRequest
            {
                Token = "some-token",
                Options = new PayPalOptionsRequest
                {
                    MakeDefault = true
                }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<token>some-token</token>", xml);
            TestHelper.AssertIncludes("<options><make-default>true</make-default></options>", xml);
        }
    }
}
