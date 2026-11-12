using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class DescriptorTest
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
            string xml = "<descriptor>" +
                "<name>company*name</name>" +
                "<phone>3334445555</phone>" +
                "<url>example.com</url>" +
            "</descriptor>";
            var node = nodeFromXml(xml);

            Descriptor descriptor = new Descriptor(node);

            Assert.AreEqual("company*name", descriptor.Name);
            Assert.AreEqual("3334445555", descriptor.Phone);
            Assert.AreEqual("example.com", descriptor.Url);
        }
    }
}
