using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodAddressRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PaymentMethodAddressRequest
            {
                StreetAddress = "1 E Main St",
                ExtendedAddress = "Apt 3",
                Locality = "Chicago",
                Region = "IL",
                PostalCode = "60622",
                Options = new PaymentMethodAddressOptionsRequest
                {
                    UpdateExisting = true
                }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<street-address>1 E Main St</street-address>", xml);
            TestHelper.AssertIncludes("<extended-address>Apt 3</extended-address>", xml);
            TestHelper.AssertIncludes("<locality>Chicago</locality>", xml);
            TestHelper.AssertIncludes("<region>IL</region>", xml);
            TestHelper.AssertIncludes("<postal-code>60622</postal-code>", xml);
            TestHelper.AssertIncludes("<options>", xml);
            TestHelper.AssertIncludes("<update-existing>true</update-existing>", xml);
        }
    }
}
