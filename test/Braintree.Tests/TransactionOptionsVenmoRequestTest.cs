using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionOptionsVenmoRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionOptionsVenmoRequest
            {
                ProfileId = "venmo-profile-id"
            };

            string xml = request.ToXml("venmo");

            TestHelper.AssertIncludes("<profile-id>venmo-profile-id</profile-id>", xml);
        }
    }
}
