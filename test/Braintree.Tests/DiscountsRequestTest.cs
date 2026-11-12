using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class DiscountsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new DiscountsRequest
            {
                Add = new AddDiscountRequest[]
                {
                    new AddDiscountRequest
                    {
                        Amount = 9.99M,
                        InheritedFromId = "discount_15"
                    }
                },
                Remove = new string[] { "discount_7" },
                Update = new UpdateDiscountRequest[]
                {
                    new UpdateDiscountRequest
                    {
                        Amount = 5.00M,
                        ExistingId = "discount_10"
                    }
                }
            };

            string xml = request.ToXml("discounts");

            TestHelper.AssertIncludes("<add type=\"array\"><item><amount>9.99</amount><inherited-from-id>discount_15</inherited-from-id></item></add>", xml);
            TestHelper.AssertIncludes("<remove type=\"array\"><item>discount_7</item></remove>", xml);
            TestHelper.AssertIncludes("<update type=\"array\"><item><amount>5.00</amount><existing-id>discount_10</existing-id></item></update>", xml);
        }
    }
}
