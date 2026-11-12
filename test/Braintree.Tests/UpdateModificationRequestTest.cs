using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class UpdateModificationRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new UpdateModificationRequest
            {
                ExistingId = "increase_10",
                Amount = 9.99M,
                NeverExpires = true,
                NumberOfBillingCycles = 3,
                Quantity = 2
            };

            string xml = request.ToXml("modification");

            TestHelper.AssertIncludes("<existing-id>increase_10</existing-id>", xml);
            TestHelper.AssertIncludes("<amount>9.99</amount>", xml);
            TestHelper.AssertIncludes("<never-expires>true</never-expires>", xml);
            TestHelper.AssertIncludes("<number-of-billing-cycles>3</number-of-billing-cycles>", xml);
            TestHelper.AssertIncludes("<quantity>2</quantity>", xml);
        }
    }
}
