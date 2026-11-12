using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class CreditCardAddressOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new CreditCardAddressOptionsRequest
            {
                UpdateExisting = true
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<update-existing>true</update-existing>", xml);
        }
    }
}
