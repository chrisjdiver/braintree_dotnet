using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class OAuthRevokeAccessTokenRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new OAuthRevokeAccessTokenRequest
            {
                Token = "access_token"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<credentials>", xml);
            TestHelper.AssertIncludes("<token>access_token</token>", xml);
        }
    }
}
