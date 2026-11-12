using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class AddAddOnRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new AddAddOnRequest
            {
                Amount = 9.99M,
                NeverExpires = true,
                NumberOfBillingCycles = 12,
                Quantity = 2,
                InheritedFromId = "increase_30"
            };

            string xml = request.ToXml("modification");

            TestHelper.AssertIncludes("<amount>9.99</amount>", xml);
            TestHelper.AssertIncludes("<never-expires>true</never-expires>", xml);
            TestHelper.AssertIncludes("<number-of-billing-cycles>12</number-of-billing-cycles>", xml);
            TestHelper.AssertIncludes("<quantity>2</quantity>", xml);
            TestHelper.AssertIncludes("<inherited-from-id>increase_30</inherited-from-id>", xml);
        }
    }
}
