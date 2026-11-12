using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PayPalAccountOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PayPalOptionsRequest
            {
                MakeDefault = true
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<make-default>true</make-default>", xml);
        }
    }
}
