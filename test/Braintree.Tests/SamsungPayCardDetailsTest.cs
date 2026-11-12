#pragma warning disable 618

using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class SamsungPayCardDetailsTest
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
            string xml = "<samsung-pay-card>" +
                "<bin>411111</bin>" +
                "<cardholder-name>John Doe</cardholder-name>" +
                "<expiration-month>05</expiration-month>" +
                "<expiration-year>2025</expiration-year>" +
                "<expired>false</expired>" +
                "<image-url>https://example.com/image.png</image-url>" +
                "<last-4>1111</last-4>" +
                "<source-card-last-4>2222</source-card-last-4>" +
                "<token>samsung_token</token>" +
                "<unique-number-identifier>uni_id</unique-number-identifier>" +
                "<created-at>2024-01-01T00:00:00Z</created-at>" +
                "<updated-at>2024-01-02T00:00:00Z</updated-at>" +
                "</samsung-pay-card>";
            var node = nodeFromXml(xml);

            SamsungPayCardDetails details = new SamsungPayCardDetails(node);

            Assert.AreEqual("411111", details.Bin);
            Assert.AreEqual("John Doe", details.CardholderName);
            Assert.AreEqual("05", details.ExpirationMonth);
            Assert.AreEqual("2025", details.ExpirationYear);
            Assert.AreEqual("05/2025", details.ExpirationDate);
            Assert.AreEqual(false, details.IsExpired);
            Assert.AreEqual("https://example.com/image.png", details.ImageUrl);
            Assert.AreEqual("1111", details.LastFour);
            Assert.AreEqual("2222", details.SourceCardLastFour);
            Assert.AreEqual("samsung_token", details.Token);
            Assert.AreEqual("uni_id", details.UniqueNumberIdentifier);
            Assert.AreEqual("411111******1111", details.MaskedNumber);
        }
    }
}
