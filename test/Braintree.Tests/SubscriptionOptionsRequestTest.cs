using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class SubscriptionOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new SubscriptionOptionsRequest
            {
                DoNotInheritAddOnsOrDiscounts = true,
                ProrateCharges = true,
                ReplaceAllAddOnsAndDiscounts = true,
                RevertSubscriptionOnProrationFailure = true,
                StartImmediately = true,
                PayPal = new SubscriptionOptionsPayPalRequest
                {
                    Description = "v"
                }
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<replace-all-add-ons-and-discounts>true</replace-all-add-ons-and-discounts>", xml);
            TestHelper.AssertIncludes("<prorate-charges>true</prorate-charges>", xml);
            TestHelper.AssertIncludes("<do-not-inherit-add-ons-or-discounts>true</do-not-inherit-add-ons-or-discounts>", xml);
            TestHelper.AssertIncludes("<revert-subscription-on-proration-failure>true</revert-subscription-on-proration-failure>", xml);
            TestHelper.AssertIncludes("<start-immediately>true</start-immediately>", xml);
            TestHelper.AssertIncludes("<paypal><description>v</description></paypal>", xml);
        }
    }
}
