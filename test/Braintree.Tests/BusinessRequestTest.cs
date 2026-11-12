using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class BusinessRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new BusinessRequest
            {
                DbaName = "Acme",
                LegalName = "Acme Corporation",
                Address = new AddressRequest
                {
                    StreetAddress = "1 E Main St"
                },
                TaxId = "123456789"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<dba-name>Acme</dba-name>", xml);
            TestHelper.AssertIncludes("<legal-name>Acme Corporation</legal-name>", xml);
            TestHelper.AssertIncludes("<address><street-address>1 E Main St</street-address></address>", xml);
            TestHelper.AssertIncludes("<tax-id>123456789</tax-id>", xml);
        }
    }
}
