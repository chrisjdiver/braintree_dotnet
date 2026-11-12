using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class IndividualRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new IndividualRequest
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane@example.com",
                Phone = "5551234567",
                DateOfBirth = "1990-01-01",
                Ssn = "123-45-6789",
                Address = new AddressRequest
                {
                    StreetAddress = "123 Main St",
                    Locality = "Chicago",
                    Region = "IL",
                    PostalCode = "60622"
                }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<individual>", xml);
            TestHelper.AssertIncludes("<first-name>Jane</first-name>", xml);
            TestHelper.AssertIncludes("<last-name>Doe</last-name>", xml);
            TestHelper.AssertIncludes("<email>jane@example.com</email>", xml);
            TestHelper.AssertIncludes("<phone>5551234567</phone>", xml);
            TestHelper.AssertIncludes("<address>", xml);
            TestHelper.AssertIncludes("<street-address>123 Main St</street-address>", xml);
            TestHelper.AssertIncludes("<locality>Chicago</locality>", xml);
            TestHelper.AssertIncludes("<region>IL</region>", xml);
            TestHelper.AssertIncludes("<postal-code>60622</postal-code>", xml);
            TestHelper.AssertIncludes("<date-of-birth>1990-01-01</date-of-birth>", xml);
            TestHelper.AssertIncludes("<ssn>123-45-6789</ssn>", xml);
        }
    }
}
