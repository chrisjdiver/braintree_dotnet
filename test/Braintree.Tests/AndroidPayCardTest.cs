using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class AndroidPayCardTest
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
            string xml = "<android-pay-card>" +
                "<bin>411111</bin>" +
                "<business>No</business>" +
                "<commercial>Yes</commercial>" +
                "<consumer>No</consumer>" +
                "<corporate>No</corporate>" +
                "<country-of-issuance>USA</country-of-issuance>" +
                "<customer-id>cust-123</customer-id>" +
                "<debit>Yes</debit>" +
                "<durbin-regulated>No</durbin-regulated>" +
                "<expiration-month>05</expiration-month>" +
                "<expiration-year>2025</expiration-year>" +
                "<google-transaction-id>google-txn-123</google-transaction-id>" +
                "<healthcare>No</healthcare>" +
                "<image-url>https://example.com/image.png</image-url>" +
                "<default type=\"boolean\">true</default>" +
                "<is-network-tokenized type=\"boolean\">true</is-network-tokenized>" +
                "<issuing-bank>Issuer</issuing-bank>" +
                "<payroll>No</payroll>" +
                "<prepaid>No</prepaid>" +
                "<prepaid-reloadable>No</prepaid-reloadable>" +
                "<product-id>prod-1</product-id>" +
                "<purchase>Yes</purchase>" +
                "<source-card-last-4>1111</source-card-last-4>" +
                "<source-card-type>Visa</source-card-type>" +
                "<source-description>Visa 1111</source-description>" +
                "<token>token-123</token>" +
                "<virtual-card-last-4>9999</virtual-card-last-4>" +
                "<virtual-card-type>Visa</virtual-card-type>" +
                "<subscriptions type=\"array\"></subscriptions>" +
            "</android-pay-card>";
            var node = nodeFromXml(xml);

            AndroidPayCard card = new AndroidPayCard(node, gateway);

            Assert.AreEqual("411111", card.Bin);
            Assert.AreEqual("No", card.Business);
            Assert.AreEqual("Yes", card.Commercial);
            Assert.AreEqual("cust-123", card.CustomerId);
            Assert.AreEqual("05", card.ExpirationMonth);
            Assert.AreEqual("2025", card.ExpirationYear);
            Assert.AreEqual("google-txn-123", card.GoogleTransactionId);
            Assert.AreEqual(true, card.IsDefault);
            Assert.AreEqual(true, card.IsNetworkTokenized);
            Assert.AreEqual("1111", card.SourceCardLast4);
            Assert.AreEqual("Visa", card.SourceCardType);
            Assert.AreEqual("token-123", card.Token);
            Assert.AreEqual("9999", card.VirtualCardLast4);
            Assert.AreEqual("Visa", card.VirtualCardType);
            Assert.AreEqual("Visa", card.CardType);
            Assert.AreEqual("9999", card.Last4);
        }
    }
}
