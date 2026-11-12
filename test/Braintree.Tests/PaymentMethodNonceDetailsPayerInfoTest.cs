using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodNonceDetailsPayerInfoTest
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
            string xml = "<payer-info>" +
                "<email>payer@example.com</email>" +
                "<first-name>Jane</first-name>" +
                "<last-name>Doe</last-name>" +
                "<payer-id>PAYER123</payer-id>" +
                "<country-code>US</country-code>" +
                "</payer-info>";
            var node = nodeFromXml(xml);

            PaymentMethodNonceDetailsPayerInfo payerInfo = new PaymentMethodNonceDetailsPayerInfo(node);

            Assert.AreEqual("payer@example.com", payerInfo.Email);
            Assert.AreEqual("Jane", payerInfo.FirstName);
            Assert.AreEqual("Doe", payerInfo.LastName);
            Assert.AreEqual("PAYER123", payerInfo.PayerId);
            Assert.AreEqual("US", payerInfo.CountryCode);
        }
    }
}
