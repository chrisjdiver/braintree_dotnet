using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class VenmoAccountDetailsTest
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
            string xml = "<venmo-account>" +
                "<token>venmo_token</token>" +
                "<username>venmojoe</username>" +
                "<venmo-user-id>venmo_user_id</venmo-user-id>" +
                "<image-url>https://example.com/image.png</image-url>" +
                "<source-description>Venmo Account: venmojoe</source-description>" +
                "</venmo-account>";
            var node = nodeFromXml(xml);

            VenmoAccountDetails details = new VenmoAccountDetails(node);

            Assert.AreEqual("venmo_token", details.Token);
            Assert.AreEqual("venmojoe", details.Username);
            Assert.AreEqual("venmo_user_id", details.VenmoUserId);
            Assert.AreEqual("https://example.com/image.png", details.ImageUrl);
            Assert.AreEqual("Venmo Account: venmojoe", details.SourceDescription);
        }
    }
}
