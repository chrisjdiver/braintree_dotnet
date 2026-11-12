using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class UpdateDiscountRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new UpdateDiscountRequest
            {
                ExistingId = "discount_10",
                Amount = 5.00M,
                NeverExpires = true,
                NumberOfBillingCycles = 2,
                Quantity = 1
            };

            string xml = request.ToXml("discount");

            TestHelper.AssertIncludes("<existing-id>discount_10</existing-id>", xml);
            TestHelper.AssertIncludes("<amount>5.00</amount>", xml);
            TestHelper.AssertIncludes("<never-expires>true</never-expires>", xml);
            TestHelper.AssertIncludes("<number-of-billing-cycles>2</number-of-billing-cycles>", xml);
            TestHelper.AssertIncludes("<quantity>1</quantity>", xml);
        }
    }
}
