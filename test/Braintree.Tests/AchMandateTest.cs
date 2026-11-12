using System;
using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class AchMandateTest
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
            string xml = "<ach-mandate>" +
                "<text>Mandate text</text>" +
                "<accepted-at type=\"datetime\">2018-05-15T12:00:00Z</accepted-at>" +
            "</ach-mandate>";
            var node = nodeFromXml(xml);

            AchMandate mandate = new AchMandate(node);

            Assert.AreEqual("Mandate text", mandate.Text);
            Assert.AreEqual(new DateTime(2018, 5, 15, 12, 0, 0, DateTimeKind.Utc), mandate.AcceptedAt);
        }
    }
}
