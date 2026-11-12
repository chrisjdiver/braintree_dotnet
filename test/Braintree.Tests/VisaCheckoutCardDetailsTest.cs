#pragma warning disable 618

using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class VisaCheckoutCardDetailsTest
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
            string xml = "<visa-checkout-card>" +
                "<billing-address><street-address>1 Main St</street-address></billing-address>" +
                "<bin>411111</bin>" +
                "<call-id>call_id</call-id>" +
                "<cardholder-name>John Doe</cardholder-name>" +
                "<created-at>2024-01-01T00:00:00Z</created-at>" +
                "<expiration-month>05</expiration-month>" +
                "<expiration-year>2025</expiration-year>" +
                "<image-url>https://example.com/image.png</image-url>" +
                "<expired>false</expired>" +
                "<last-4>1111</last-4>" +
                "<token>visa_token</token>" +
                "<unique-number-identifier>uni_id</unique-number-identifier>" +
                "<updated-at>2024-01-02T00:00:00Z</updated-at>" +
                "</visa-checkout-card>";
            var node = nodeFromXml(xml);

            VisaCheckoutCardDetails details = new VisaCheckoutCardDetails(node);

            Assert.AreEqual("1 Main St", details.BillingAddress.StreetAddress);
            Assert.AreEqual("411111", details.Bin);
            Assert.AreEqual("call_id", details.CallId);
            Assert.AreEqual("John Doe", details.CardholderName);
            Assert.AreEqual("05", details.ExpirationMonth);
            Assert.AreEqual("2025", details.ExpirationYear);
            Assert.AreEqual("05/2025", details.ExpirationDate);
            Assert.AreEqual("https://example.com/image.png", details.ImageUrl);
            Assert.AreEqual(false, details.IsExpired);
            Assert.AreEqual("1111", details.LastFour);
            Assert.AreEqual("visa_token", details.Token);
            Assert.AreEqual("uni_id", details.UniqueNumberIdentifier);
            Assert.AreEqual("411111******1111", details.MaskedNumber);
        }
    }
}
