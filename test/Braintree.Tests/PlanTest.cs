using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class PlanTest
    {
        private BraintreeGateway gateway;

        [SetUp]
        public void Setup()
        {
            gateway = new BraintreeGateway
            {
                Environment = Environment.DEVELOPMENT,
                MerchantId = "integration_merchant_id",
                PublicKey = "integration_public_key",
                PrivateKey = "integration_private_key"
            };
        }

        private NodeWrapper nodeFromXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return new NodeWrapper(doc.DocumentElement);
        }

        [Test]
        public void IncludesFields()
        {
            string xml = "<plan>" +
                "<billing-day-of-month type=\"integer\">5</billing-day-of-month>" +
                "<billing-frequency type=\"integer\">1</billing-frequency>" +
                "<currency-iso-code>USD</currency-iso-code>" +
                "<description>A test plan</description>" +
                "<id>plan_id</id>" +
                "<name>Test Plan</name>" +
                "<number-of-billing-cycles type=\"integer\">12</number-of-billing-cycles>" +
                "<price>9.99</price>" +
                "<trial-period type=\"boolean\">true</trial-period>" +
                "<trial-duration type=\"integer\">7</trial-duration>" +
                "<trial-duration-unit>day</trial-duration-unit>" +
                "<add-ons type=\"array\">" +
                    "<add-on>" +
                        "<id>add_on_id</id>" +
                        "<name>An Add On</name>" +
                    "</add-on>" +
                "</add-ons>" +
                "<discounts type=\"array\">" +
                    "<discount>" +
                        "<id>discount_id</id>" +
                        "<name>A Discount</name>" +
                    "</discount>" +
                "</discounts>" +
                "</plan>";
            var node = nodeFromXml(xml);

            Plan plan = new Plan(node, gateway);

            Assert.AreEqual(5, plan.BillingDayOfMonth);
            Assert.AreEqual(1, plan.BillingFrequency);
            Assert.AreEqual("USD", plan.CurrencyIsoCode);
            Assert.AreEqual("A test plan", plan.Description);
            Assert.AreEqual("plan_id", plan.Id);
            Assert.AreEqual("Test Plan", plan.Name);
            Assert.AreEqual(12, plan.NumberOfBillingCycles);
            Assert.AreEqual(9.99M, plan.Price);
            Assert.AreEqual(true, plan.TrialPeriod);
            Assert.AreEqual(7, plan.TrialDuration);
            Assert.AreEqual(PlanDurationUnit.DAY, plan.TrialDurationUnit);
            Assert.AreEqual(1, plan.AddOns.Count);
            Assert.AreEqual("add_on_id", plan.AddOns[0].Id);
            Assert.AreEqual(1, plan.Discounts.Count);
            Assert.AreEqual("discount_id", plan.Discounts[0].Id);
        }
    }
}
