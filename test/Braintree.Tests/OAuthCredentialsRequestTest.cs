using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class OAuthCredentialsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new OAuthCredentialsRequest
            {
                Code = "integration_oauth_auth_code",
                Scope = "read_write",
                GrantType = "authorization_code",
                RefreshToken = "refresh_token"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<code>integration_oauth_auth_code</code>", xml);
            TestHelper.AssertIncludes("<refresh_token>refresh_token</refresh_token>", xml);
            TestHelper.AssertIncludes("<scope>read_write</scope>", xml);
            TestHelper.AssertIncludes("<grant_type>authorization_code</grant_type>", xml);
        }
    }
}
