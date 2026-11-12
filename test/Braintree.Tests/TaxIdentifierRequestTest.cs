using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TaxIdentifierRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TaxIdentifierRequest
            {
                CountryCode = "US",
                Identifier = "v"
            };

            string xml = request.ToXml("tax-identifier");

            TestHelper.AssertIncludes("<countryCode>US</countryCode>", xml);
            TestHelper.AssertIncludes("<identifier>v</identifier>", xml);
        }

        [Test]
        public void ToQueryString_IncludesAllData()
        {
            var request = new TaxIdentifierRequest
            {
                CountryCode = "US",
                Identifier = "v"
            };

            string queryString = request.ToQueryString("tax-identifier");

            TestHelper.AssertIncludes("tax_identifier%5BcountryCode%5D=US", queryString);
            TestHelper.AssertIncludes("tax_identifier%5Bidentifier%5D=v", queryString);
        }
    }
}
