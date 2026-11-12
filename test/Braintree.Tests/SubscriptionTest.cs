using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class SubscriptionTest
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
            string xml = "<subscription>" +
                "<balance>10.00</balance>" +
                "<billing-day-of-month>5</billing-day-of-month>" +
                "<billing-period-end-date>2024-01-31</billing-period-end-date>" +
                "<billing-period-start-date>2024-01-01</billing-period-start-date>" +
                "<current-billing-cycle>2</current-billing-cycle>" +
                "<days-past-due>0</days-past-due>" +
                "<descriptor><name>Company Name</name><phone>3334445555</phone><url>example.com</url></descriptor>" +
                "<description>A subscription</description>" +
                "<failure-count>0</failure-count>" +
                "<first-billing-date>2024-01-01</first-billing-date>" +
                "<created-at>2024-01-01T00:00:00Z</created-at>" +
                "<updated-at>2024-01-02T00:00:00Z</updated-at>" +
                "<id>sub_id</id>" +
                "<next-bill-amount>20.00</next-bill-amount>" +
                "<next-billing-date>2024-02-01</next-billing-date>" +
                "<next-billing-period-amount>20.00</next-billing-period-amount>" +
                "<never-expires>true</never-expires>" +
                "<number-of-billing-cycles>12</number-of-billing-cycles>" +
                "<payment-method-token>pmt_token</payment-method-token>" +
                "<paid-through-date>2024-01-31</paid-through-date>" +
                "<plan-id>integration_plan</plan-id>" +
                "<price>20.00</price>" +
                "<status>Active</status>" +
                "<trial-period>false</trial-period>" +
                "<trial-duration>0</trial-duration>" +
                "<merchant-account-id>ma_id</merchant-account-id>" +
                "</subscription>";
            var node = nodeFromXml(xml);

            Subscription subscription = new Subscription(node, gateway);

            Assert.AreEqual(10.00M, subscription.Balance);
            Assert.AreEqual(5, subscription.BillingDayOfMonth);
            Assert.AreEqual(2, subscription.CurrentBillingCycle);
            Assert.AreEqual(0, subscription.DaysPastDue);
            Assert.AreEqual("Company Name", subscription.Descriptor.Name);
            Assert.AreEqual("A subscription", subscription.Description);
            Assert.AreEqual(0, subscription.FailureCount);
            Assert.AreEqual("sub_id", subscription.Id);
            Assert.AreEqual(20.00M, subscription.NextBillAmount);
            Assert.AreEqual(20.00M, subscription.NextBillingPeriodAmount);
            Assert.AreEqual(true, subscription.NeverExpires);
            Assert.AreEqual(12, subscription.NumberOfBillingCycles);
            Assert.AreEqual("pmt_token", subscription.PaymentMethodToken);
            Assert.AreEqual("integration_plan", subscription.PlanId);
            Assert.AreEqual(20.00M, subscription.Price);
            Assert.AreEqual(SubscriptionStatus.ACTIVE, subscription.Status);
            Assert.AreEqual(false, subscription.HasTrialPeriod);
            Assert.AreEqual(0, subscription.TrialDuration);
            Assert.AreEqual("ma_id", subscription.MerchantAccountId);
        }
    }
}
