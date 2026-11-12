using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class AddOnsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new AddOnsRequest
            {
                Add = new AddAddOnRequest[]
                {
                    new AddAddOnRequest
                    {
                        Amount = 9.99M,
                        InheritedFromId = "increase_30"
                    }
                },
                Remove = new string[] { "discount_7" },
                Update = new UpdateAddOnRequest[]
                {
                    new UpdateAddOnRequest
                    {
                        Amount = 5.00M,
                        ExistingId = "increase_10"
                    }
                }
            };

            string xml = request.ToXml("add-ons");

            TestHelper.AssertIncludes("<add type=\"array\"><item><amount>9.99</amount><inherited-from-id>increase_30</inherited-from-id></item></add>", xml);
            TestHelper.AssertIncludes("<remove type=\"array\"><item>discount_7</item></remove>", xml);
            TestHelper.AssertIncludes("<update type=\"array\"><item><amount>5.00</amount><existing-id>increase_10</existing-id></item></update>", xml);
        }
    }
}
