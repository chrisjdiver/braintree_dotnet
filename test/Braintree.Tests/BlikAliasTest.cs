using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class BlikAliasTest
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
            string xml = "<blik-alias>" +
                "<key>unique-key-1</key>" +
                "<label>unique-label-1</label>" +
            "</blik-alias>";
            var node = nodeFromXml(xml);

            BlikAlias alias = new BlikAlias(node);

            Assert.AreEqual("unique-key-1", alias.Key);
            Assert.AreEqual("unique-label-1", alias.Label);
        }
    }
}
