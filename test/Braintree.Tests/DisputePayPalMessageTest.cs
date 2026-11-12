using System;
using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class DisputePayPalMessageTest
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
            string xml = "<paypal-message>" +
                "<message>a message</message>" +
                "<sender>seller</sender>" +
                "<sent-at>2019-01-01T00:00:00Z</sent-at>" +
            "</paypal-message>";
            var node = nodeFromXml(xml);

            DisputePayPalMessage message = new DisputePayPalMessage(node);

            Assert.AreEqual("a message", message.Message);
            Assert.AreEqual("seller", message.Sender);
            Assert.AreEqual(new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc), message.SentAt);
        }
    }
}
