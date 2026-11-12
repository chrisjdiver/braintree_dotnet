#pragma warning disable 618

using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class VisaCheckoutCardTest
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
            string xml = "<visa-checkout-card>" +
                "<billing-address><street-address>1 Main St</street-address></billing-address>" +
                "<bin>411111</bin>" +
                "<call-id>call_id</call-id>" +
                "<cardholder-name>John Doe</cardholder-name>" +
                "<created-at>2024-01-01T00:00:00Z</created-at>" +
                "<customer-id>cust_id</customer-id>" +
                "<expiration-month>05</expiration-month>" +
                "<expiration-year>2025</expiration-year>" +
                "<image-url>https://example.com/image.png</image-url>" +
                "<default>true</default>" +
                "<expired>false</expired>" +
                "<last-4>1111</last-4>" +
                "<token>visa_token</token>" +
                "<unique-number-identifier>uni_id</unique-number-identifier>" +
                "<updated-at>2024-01-02T00:00:00Z</updated-at>" +
                "</visa-checkout-card>";
            var node = nodeFromXml(xml);

            VisaCheckoutCard card = new VisaCheckoutCard(node, gateway);

            Assert.AreEqual("1 Main St", card.BillingAddress.StreetAddress);
            Assert.AreEqual("411111", card.Bin);
            Assert.AreEqual("call_id", card.CallId);
            Assert.AreEqual("John Doe", card.CardholderName);
            Assert.AreEqual("cust_id", card.CustomerId);
            Assert.AreEqual("05", card.ExpirationMonth);
            Assert.AreEqual("2025", card.ExpirationYear);
            Assert.AreEqual("05/2025", card.ExpirationDate);
            Assert.AreEqual("https://example.com/image.png", card.ImageUrl);
            Assert.AreEqual(true, card.IsDefault);
            Assert.AreEqual(false, card.IsExpired);
            Assert.AreEqual("1111", card.LastFour);
            Assert.AreEqual("visa_token", card.Token);
            Assert.AreEqual("uni_id", card.UniqueNumberIdentifier);
            Assert.AreEqual("411111******1111", card.MaskedNumber);
        }
    }
}
