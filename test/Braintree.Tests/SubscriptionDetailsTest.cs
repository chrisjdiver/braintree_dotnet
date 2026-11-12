using System;
using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class SubscriptionDetailsTest
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
            string xml = "<subscription>" +
                "<billing-period-end-date>2024-01-31</billing-period-end-date>" +
                "<billing-period-start-date>2024-01-01</billing-period-start-date>" +
                "</subscription>";
            var node = nodeFromXml(xml);

            SubscriptionDetails details = new SubscriptionDetails(node);

            Assert.AreEqual(new DateTime(2024, 1, 31), details.BillingPeriodEndDate);
            Assert.AreEqual(new DateTime(2024, 1, 1), details.BillingPeriodStartDate);
        }
    }
}
