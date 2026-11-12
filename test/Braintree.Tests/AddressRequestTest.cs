using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class AddressRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new AddressRequest
            {
                Company = "Angelo Co.",
                CountryCodeAlpha2 = "US",
                CountryCodeAlpha3 = "USA",
                CountryCodeNumeric = "840",
                CountryName = "United States of America",
                ExtendedAddress = "Apt 3",
                FirstName = "Michael",
                InternationalPhone = new InternationalPhoneRequest
                {
                    CountryCode = "1",
                    NationalNumber = "3121234567"
                },
                LastName = "Angelo",
                Locality = "Chicago",
                PhoneNumber = "312.555.1111",
                PostalCode = "60622",
                Region = "IL",
                ShippingMethod = Braintree.ShippingMethod.GROUND,
                StreetAddress = "1 E Main St"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<company>Angelo Co.</company>", xml);
            TestHelper.AssertIncludes("<country-code-alpha2>US</country-code-alpha2>", xml);
            TestHelper.AssertIncludes("<country-code-alpha3>USA</country-code-alpha3>", xml);
            TestHelper.AssertIncludes("<country-code-numeric>840</country-code-numeric>", xml);
            TestHelper.AssertIncludes("<country-name>United States of America</country-name>", xml);
            TestHelper.AssertIncludes("<extended-address>Apt 3</extended-address>", xml);
            TestHelper.AssertIncludes("<first-name>Michael</first-name>", xml);
            TestHelper.AssertIncludes("<international-phone><country-code>1</country-code><national-number>3121234567</national-number></international-phone>", xml);
            TestHelper.AssertIncludes("<last-name>Angelo</last-name>", xml);
            TestHelper.AssertIncludes("<locality>Chicago</locality>", xml);
            TestHelper.AssertIncludes("<phone-number>312.555.1111</phone-number>", xml);
            TestHelper.AssertIncludes("<postal-code>60622</postal-code>", xml);
            TestHelper.AssertIncludes("<region>IL</region>", xml);
            TestHelper.AssertIncludes("<shipping-method>ground</shipping-method>", xml);
            TestHelper.AssertIncludes("<street-address>1 E Main St</street-address>", xml);
        }
    }
}
