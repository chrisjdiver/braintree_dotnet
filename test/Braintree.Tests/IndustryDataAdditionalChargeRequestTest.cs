using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class IndustryDataAdditionalChargeRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new IndustryDataAdditionalChargeRequest
            {
                AdditionalChargeKind = IndustryDataAdditionalChargeKind.RESTAURANT,
                Amount = 9.99M
            };

            string xml = request.ToXml("additional-charge");

            TestHelper.AssertIncludes("<kind>restaurant</kind>", xml);
            TestHelper.AssertIncludes("<amount>9.99</amount>", xml);
        }
    }
}
