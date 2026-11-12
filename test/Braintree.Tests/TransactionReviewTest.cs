using System;
using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionReviewTest
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
            string xml = "<transaction-review>" +
                "<transaction-id>txn_id</transaction-id>" +
                "<decision>decision_value</decision>" +
                "<reviewer-email>reviewer@example.com</reviewer-email>" +
                "<reviewer-note>a note</reviewer-note>" +
                "<reviewed-time>2024-01-01T00:00:00Z</reviewed-time>" +
                "</transaction-review>";
            var node = nodeFromXml(xml);

            TransactionReview review = new TransactionReview(node);

            Assert.AreEqual("txn_id", review.TransactionId);
            Assert.AreEqual("decision_value", review.Decision);
            Assert.AreEqual("reviewer@example.com", review.ReviewerEmail);
            Assert.AreEqual("a note", review.ReviewerNote);
            Assert.AreEqual(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), review.ReviewedTime);
        }
    }
}
