using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class DisputeEvidenceTest
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
            string xml = "<evidence>" +
                "<created-at>2019-01-01T00:00:00Z</created-at>" +
                "<sent-to-processor-at>2019-01-02T00:00:00Z</sent-to-processor-at>" +
                "<comment>a comment</comment>" +
                "<id>evidence-id</id>" +
                "<url>https://example.com/evidence</url>" +
                "<tag>GENERAL</tag>" +
                "<category>DEVICE_ID</category>" +
                "<sequence-number>3</sequence-number>" +
            "</evidence>";
            var node = nodeFromXml(xml);

            DisputeEvidence evidence = new DisputeEvidence(node);

            Assert.AreEqual("a comment", evidence.Comment);
            Assert.AreEqual("evidence-id", evidence.Id);
            Assert.AreEqual("https://example.com/evidence", evidence.Url);
            Assert.AreEqual("GENERAL", evidence.Tag);
            Assert.AreEqual("DEVICE_ID", evidence.Category);
            Assert.AreEqual("3", evidence.SequenceNumber);
        }
    }
}
