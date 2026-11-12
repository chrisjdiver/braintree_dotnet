using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionOptionsThreeDSecureRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionOptionsThreeDSecureRequest
            {
                Required = true
            };

            string xml = request.ToXml("three-d-secure");

            TestHelper.AssertIncludes("<required>true</required>", xml);
        }
    }
}
