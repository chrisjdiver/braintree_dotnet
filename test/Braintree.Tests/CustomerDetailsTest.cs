using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class CustomerDetailsTest
    {
        private BraintreeGateway gateway;

        [SetUp]
        public void Setup()
        {
            gateway = new BraintreeGateway
            {
                Environment = Environment.DEVELOPMENT,
                MerchantId = "integration_merchant_id",
                PublicKey = "integration_public_key",
                PrivateKey = "integration_private_key"
            };
        }

        private NodeWrapper nodeFromXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return new NodeWrapper(doc.DocumentElement);
        }

        [Test]
        public void IncludesFields()
        {
            string xml = "<customer>" +
            "<id>customer-123</id>" +
            "<first-name>Jane</first-name>" +
            "<last-name>Doe</last-name>" +
            "<company>Acme Inc</company>" +
            "<email>jane@example.com</email>" +
            "<phone>555-1234</phone>" +
            "<fax>555-5678</fax>" +
            "<website>www.example.com</website>" +
            "<international-phone>" +
                "<country-code>1</country-code>" +
                "<national-number>5551234</national-number>" +
            "</international-phone>" +
            "</customer>";
            var node = nodeFromXml(xml);

            CustomerDetails details = new CustomerDetails(node, gateway);

            Assert.AreEqual("customer-123", details.Id);
            Assert.AreEqual("Jane", details.FirstName);
            Assert.AreEqual("Doe", details.LastName);
            Assert.AreEqual("Acme Inc", details.Company);
            Assert.AreEqual("jane@example.com", details.Email);
            Assert.AreEqual("555-1234", details.Phone);
            Assert.AreEqual("555-5678", details.Fax);
            Assert.AreEqual("www.example.com", details.Website);
            Assert.AreEqual("1", details.InternationalPhone.CountryCode);
            Assert.AreEqual("5551234", details.InternationalPhone.NationalNumber);
        }
    }
}
