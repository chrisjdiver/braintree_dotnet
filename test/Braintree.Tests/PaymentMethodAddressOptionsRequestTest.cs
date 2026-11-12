using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodAddressOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PaymentMethodAddressOptionsRequest
            {
                UpdateExisting = true
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<update-existing>true</update-existing>", xml);
        }
    }
}
