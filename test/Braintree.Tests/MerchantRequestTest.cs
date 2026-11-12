using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class MerchantRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new MerchantRequest
            {
                Email = "name@example.com",
                CountryCodeAlpha3 = "USA",
                CompanyName = "Ziarog LTD",
                Scope = "read_write",
                Currencies = new string[] { "USD", "GBP" },
                PaymentMethods = new string[] { "credit_card", "paypal" },
                PayPalAccount = new PayPalOnlyAccountRequest
                {
                    ClientId = "paypal_client_id",
                    ClientSecret = "paypal_client_secret"
                }
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<email>name@example.com</email>", xml);
            TestHelper.AssertIncludes("<country_code_alpha3>USA</country_code_alpha3>", xml);
            TestHelper.AssertIncludes("<company_name>Ziarog LTD</company_name>", xml);
            TestHelper.AssertIncludes("<currencies type=\"array\"><item>USD</item><item>GBP</item></currencies>", xml);
            TestHelper.AssertIncludes("<payment_methods type=\"array\"><item>credit_card</item><item>paypal</item></payment_methods>", xml);
            TestHelper.AssertIncludes("<paypal_account>", xml);
            TestHelper.AssertIncludes("<client_id>paypal_client_id</client_id>", xml);
            TestHelper.AssertIncludes("<client_secret>paypal_client_secret</client_secret>", xml);
            TestHelper.AssertIncludes("<scope>read_write</scope>", xml);
        }
    }
}
