using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class ApplicantDetailsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new ApplicantDetailsRequest
            {
                CompanyName = "Angelo Co.",
                FirstName = "Michael",
                LastName = "Angelo",
                Email = "michael@angelo.com",
                Phone = "312.555.1111",
                Address = new AddressRequest
                {
                    StreetAddress = "1 E Main St"
                },
                DateOfBirth = "1990-01-01",
                Ssn = "123-45-6789",
                TaxId = "123456789",
                RoutingNumber = "071101307",
                AccountNumber = "43759348798"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<company-name>Angelo Co.</company-name>", xml);
            TestHelper.AssertIncludes("<first-name>Michael</first-name>", xml);
            TestHelper.AssertIncludes("<last-name>Angelo</last-name>", xml);
            TestHelper.AssertIncludes("<email>michael@angelo.com</email>", xml);
            TestHelper.AssertIncludes("<phone>312.555.1111</phone>", xml);
            TestHelper.AssertIncludes("<address><street-address>1 E Main St</street-address></address>", xml);
            TestHelper.AssertIncludes("<date-of-birth>1990-01-01</date-of-birth>", xml);
            TestHelper.AssertIncludes("<ssn>123-45-6789</ssn>", xml);
            TestHelper.AssertIncludes("<tax-id>123456789</tax-id>", xml);
            TestHelper.AssertIncludes("<routing-number>071101307</routing-number>", xml);
            TestHelper.AssertIncludes("<account-number>43759348798</account-number>", xml);
        }
    }
}
