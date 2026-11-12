using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class AuthenticationInsightOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new AuthenticationInsightOptionsRequest
            {
                Amount = 9.99M
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<amount>9.99</amount>", xml);
        }
    }
}
