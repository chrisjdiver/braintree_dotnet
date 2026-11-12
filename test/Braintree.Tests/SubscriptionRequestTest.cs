using NUnit.Framework;
using Braintree.TestUtil;
using System;

namespace Braintree.Tests
{
    [TestFixture]
    public class SubscriptionRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new SubscriptionRequest
            {
                BillingDayOfMonth = 12,
                FirstBillingDate = new DateTime(2020, 1, 15),
                HasTrialPeriod = true,
                Id = "v",
                NumberOfBillingCycles = 1,
                NeverExpires = true,
                PaymentMethodToken = "v",
                PaymentMethodNonce = "v",
                PlanId = "v",
                Price = 9.99M,
                TrialDuration = 2,
                TrialDurationUnit = SubscriptionDurationUnit.MONTH,
                MerchantAccountId = "v"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<billing-day-of-month>12</billing-day-of-month>", xml);
            TestHelper.AssertIncludes("<first-billing-date type=\"datetime\">2020-01-15 00:00:00Z</first-billing-date>", xml);
            TestHelper.AssertIncludes("<payment-method-token>v</payment-method-token>", xml);
            TestHelper.AssertIncludes("<payment-method-nonce>v</payment-method-nonce>", xml);
            TestHelper.AssertIncludes("<trial-period>true</trial-period>", xml);
            TestHelper.AssertIncludes("<trial-duration>2</trial-duration>", xml);
            TestHelper.AssertIncludes("<trial-duration-unit>month</trial-duration-unit>", xml);
            TestHelper.AssertIncludes("<merchant-account-id>v</merchant-account-id>", xml);
            TestHelper.AssertIncludes("<number-of-billing-cycles>1</number-of-billing-cycles>", xml);
            TestHelper.AssertIncludes("<never-expires>true</never-expires>", xml);
            TestHelper.AssertIncludes("<id>v</id>", xml);
            TestHelper.AssertIncludes("<plan-id>v</plan-id>", xml);
            TestHelper.AssertIncludes("<price>9.99</price>", xml);
        }
    }
}
