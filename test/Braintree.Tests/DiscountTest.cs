using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class DiscountTest
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
            string xml = "<discount>" +
                "<amount>10.00</amount>" +
                "<created-at>2019-01-01T00:00:00Z</created-at>" +
                "<current-billing-cycle>2</current-billing-cycle>" +
                "<description>A discount</description>" +
                "<id>discount-id</id>" +
                "<kind>discount</kind>" +
                "<merchant-id>merchant-123</merchant-id>" +
                "<name>The Discount</name>" +
                "<never-expires>true</never-expires>" +
                "<number-of-billing-cycles>5</number-of-billing-cycles>" +
                "<quantity>3</quantity>" +
                "<updated-at>2019-02-01T00:00:00Z</updated-at>" +
            "</discount>";
            var node = nodeFromXml(xml);

            Discount discount = new Discount(node);

            Assert.AreEqual(10.00M, discount.Amount);
            Assert.AreEqual(2, discount.CurrentBillingCycle);
            Assert.AreEqual("A discount", discount.Description);
            Assert.AreEqual("discount-id", discount.Id);
            Assert.AreEqual("discount", discount.Kind);
            Assert.AreEqual("merchant-123", discount.MerchantId);
            Assert.AreEqual("The Discount", discount.Name);
            Assert.AreEqual(true, discount.NeverExpires);
            Assert.AreEqual(5, discount.NumberOfBillingCycles);
            Assert.AreEqual(3, discount.Quantity);
        }
    }
}
