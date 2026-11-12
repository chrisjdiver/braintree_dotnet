using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionDetailsTest
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
            string xml = "<transaction>" +
                "<id>txn_id</id>" +
                "<amount>12.34</amount>" +
                "</transaction>";
            var node = nodeFromXml(xml);

            TransactionDetails details = new TransactionDetails(node);

            Assert.AreEqual("txn_id", details.Id);
            Assert.AreEqual("12.34", details.Amount);
        }
    }
}
