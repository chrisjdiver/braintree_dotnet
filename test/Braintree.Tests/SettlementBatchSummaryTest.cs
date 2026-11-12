using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class SettlementBatchSummaryTest
    {
        private NodeWrapper nodeFromXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return new NodeWrapper(doc.DocumentElement);
        }

        [Test]
        public void IncludesRecords()
        {
            string xml = "<settlement-batch-summary>" +
                "<records type=\"array\">" +
                    "<record>" +
                        "<kind>sale</kind>" +
                        "<count>2</count>" +
                        "<amount-settled>100.00</amount-settled>" +
                    "</record>" +
                "</records>" +
                "</settlement-batch-summary>";
            var node = nodeFromXml(xml);

            SettlementBatchSummary summary = new SettlementBatchSummary(node);

            Assert.AreEqual(1, summary.Records.Count);
            Assert.AreEqual("sale", summary.Records[0]["kind"]);
            Assert.AreEqual("2", summary.Records[0]["count"]);
            Assert.AreEqual("100.00", summary.Records[0]["amount_settled"]);
        }
    }
}
