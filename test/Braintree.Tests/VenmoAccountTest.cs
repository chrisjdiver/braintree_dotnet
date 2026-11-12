using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class VenmoAccountTest
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
            string xml = "<venmo-account>" +
                "<token>venmo_token</token>" +
                "<username>venmojoe</username>" +
                "<venmo-user-id>venmo_user_id</venmo-user-id>" +
                "<source-description>Venmo Account: venmojoe</source-description>" +
                "<image-url>https://example.com/image.png</image-url>" +
                "<default>true</default>" +
                "<customer-id>cust_id</customer-id>" +
                "<created-at>2024-01-01T00:00:00Z</created-at>" +
                "<updated-at>2024-01-02T00:00:00Z</updated-at>" +
                "</venmo-account>";
            var node = nodeFromXml(xml);

            VenmoAccount account = new VenmoAccount(node, gateway);

            Assert.AreEqual("venmo_token", account.Token);
            Assert.AreEqual("venmojoe", account.Username);
            Assert.AreEqual("venmo_user_id", account.VenmoUserId);
            Assert.AreEqual("Venmo Account: venmojoe", account.SourceDescription);
            Assert.AreEqual("https://example.com/image.png", account.ImageUrl);
            Assert.AreEqual(true, account.IsDefault);
            Assert.AreEqual("cust_id", account.CustomerId);
        }
    }
}
