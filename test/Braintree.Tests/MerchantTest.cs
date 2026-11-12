using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class MerchantTest
    {
        private NodeWrapper nodeFromXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return new NodeWrapper(doc.DocumentElement);
        }

        [Test]
        public void IncludesFields()
        {
            string xml = "<response>" +
                "<merchant>" +
                    "<id>merchant-id</id>" +
                    "<email>merchant@example.com</email>" +
                    "<company-name>The Company</company-name>" +
                    "<country-code-alpha3>USA</country-code-alpha3>" +
                    "<country-code-alpha2>US</country-code-alpha2>" +
                    "<country-code-numeric>840</country-code-numeric>" +
                    "<country-name>United States of America</country-name>" +
                    "<merchant-accounts type=\"array\"></merchant-accounts>" +
                "</merchant>" +
                "<credentials>" +
                    "<access-token>access-token-value</access-token>" +
                    "<refresh-token>refresh-token-value</refresh-token>" +
                    "<token-type>bearer</token-type>" +
                    "<scope>read_write</scope>" +
                "</credentials>" +
            "</response>";
            var node = nodeFromXml(xml);

            Merchant merchant = new Merchant(node);

            Assert.AreEqual("merchant-id", merchant.Id);
            Assert.AreEqual("merchant@example.com", merchant.Email);
            Assert.AreEqual("The Company", merchant.CompanyName);
            Assert.AreEqual("USA", merchant.CountryCodeAlpha3);
            Assert.AreEqual("US", merchant.CountryCodeAlpha2);
            Assert.AreEqual("840", merchant.CountryCodeNumeric);
            Assert.AreEqual("United States of America", merchant.CountryName);
            Assert.AreEqual("access-token-value", merchant.Credentials.AccessToken);
            Assert.AreEqual(0, merchant.MerchantAccounts.Length);
        }
    }
}
