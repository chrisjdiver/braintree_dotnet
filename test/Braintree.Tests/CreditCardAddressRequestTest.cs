using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class CreditCardAddressRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new CreditCardAddressRequest
            {
                StreetAddress = "1 E Main St",
                Locality = "Chicago",
                Region = "IL",
                PostalCode = "60622",
                Options = new CreditCardAddressOptionsRequest
                {
                    UpdateExisting = true
                }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<street-address>1 E Main St</street-address>", xml);
            TestHelper.AssertIncludes("<locality>Chicago</locality>", xml);
            TestHelper.AssertIncludes("<region>IL</region>", xml);
            TestHelper.AssertIncludes("<postal-code>60622</postal-code>", xml);
            TestHelper.AssertIncludes("<options><update-existing>true</update-existing></options>", xml);
        }
    }
}
