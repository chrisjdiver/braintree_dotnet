using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodNonceDetailsTest
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
            string xml = "<details>" +
                "<bin>411111</bin>" +
                "<card-type>Visa</card-type>" +
                "<expiration-month>12</expiration-month>" +
                "<expiration-year>2025</expiration-year>" +
                "<is-network-tokenized type=\"boolean\">true</is-network-tokenized>" +
                "<last-four>1111</last-four>" +
                "<last-two>11</last-two>" +
                "<username>venmo_user</username>" +
                "<venmo-user-id>venmo-id-123</venmo-user-id>" +
                "<payer-info>" +
                    "<email>payer@example.com</email>" +
                    "<first-name>Jane</first-name>" +
                    "<last-name>Doe</last-name>" +
                    "<payer-id>PAYER123</payer-id>" +
                    "<country-code>US</country-code>" +
                "</payer-info>" +
                "</details>";
            var node = nodeFromXml(xml);

            PaymentMethodNonceDetails details = new PaymentMethodNonceDetails(node);

            Assert.AreEqual("411111", details.Bin);
            Assert.AreEqual("Visa", details.CardType);
            Assert.AreEqual("12", details.ExpirationMonth);
            Assert.AreEqual("2025", details.ExpirationYear);
            Assert.AreEqual(true, details.IsNetworkTokenized);
            Assert.AreEqual("1111", details.LastFour);
            Assert.AreEqual("11", details.LastTwo);
            Assert.AreEqual("venmo_user", details.Username);
            Assert.AreEqual("venmo-id-123", details.VenmoUserId);
            Assert.AreEqual("payer@example.com", details.PayerInfo.Email);
            Assert.AreEqual("Jane", details.PayerInfo.FirstName);
        }

        [Test]
        public void IncludesSepaDirectDebit()
        {
            string xml = "<details>" +
                "<bank-reference-token>QkFOSw==</bank-reference-token>" +
                "<correlation-id>corr-123</correlation-id>" +
                "<iban-last-chars>1234</iban-last-chars>" +
                "<mandate-type>one_off</mandate-type>" +
                "<merchant-or-partner-customer-id>cust-456</merchant-or-partner-customer-id>" +
                "</details>";
            var node = nodeFromXml(xml);

            PaymentMethodNonceDetails details = new PaymentMethodNonceDetails(node);

            Assert.AreEqual("1234", details.SepaDirectDebit.IbanLastChars);
            Assert.AreEqual("corr-123", details.SepaDirectDebit.CorrelationId);
        }
    }
}
