using System;
using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class DisputeStatusHistoryTest
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
            string xml = "<status-history>" +
                "<effective-date>2019-01-01T00:00:00Z</effective-date>" +
                "<disbursement-date>2019-01-02T00:00:00Z</disbursement-date>" +
                "<timestamp>2019-01-03T00:00:00Z</timestamp>" +
                "<status>open</status>" +
            "</status-history>";
            var node = nodeFromXml(xml);

            DisputeStatusHistory history = new DisputeStatusHistory(node);

            Assert.AreEqual(DisputeStatus.OPEN, history.Status);
            Assert.AreEqual(new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc), history.EffectiveDate);
            Assert.AreEqual(new DateTime(2019, 1, 2, 0, 0, 0, DateTimeKind.Utc), history.DisbursementDate);
            Assert.AreEqual(new DateTime(2019, 1, 3, 0, 0, 0, DateTimeKind.Utc), history.Timestamp);
        }
    }
}
