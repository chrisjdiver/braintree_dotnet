using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionOptionsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionOptionsRequest
            {
                StoreInVault = true,
                StoreInVaultOnSuccess = true,
                AddBillingAddressToPaymentMethod = true,
                StoreShippingAddressInVault = true,
                SubmitForSettlement = true,
                PayeeId = "payee-id-value",
                PayeeEmail = "payee@example.com",
                SkipAdvancedFraudChecking = true,
                SkipAvs = true,
                SkipCvv = true,
                ThreeDSecure = new TransactionOptionsThreeDSecureRequest
                {
                    Required = true
                },
                PayPal = new TransactionOptionsPayPalRequest
                {
                    PayeeId = "paypal-payee-id"
                },
                Venmo = new TransactionOptionsVenmoRequest
                {
                    ProfileId = "venmo-profile-id"
                },
                ProcessingOverrides = new TransactionOptionsProcessingOverridesRequest
                {
                    CustomerEmail = "customer@example.com"
                }
            };

            string xml = request.ToXml("options");

            TestHelper.AssertIncludes("<store-in-vault>true</store-in-vault>", xml);
            TestHelper.AssertIncludes("<store-in-vault-on-success>true</store-in-vault-on-success>", xml);
            TestHelper.AssertIncludes("<add-billing-address-to-payment-method>true</add-billing-address-to-payment-method>", xml);
            TestHelper.AssertIncludes("<store-shipping-address-in-vault>true</store-shipping-address-in-vault>", xml);
            TestHelper.AssertIncludes("<submit-for-settlement>true</submit-for-settlement>", xml);
            TestHelper.AssertIncludes("<payee-id>payee-id-value</payee-id>", xml);
            TestHelper.AssertIncludes("<payee-email>payee@example.com</payee-email>", xml);
            TestHelper.AssertIncludes("<skip-advanced-fraud-checking>true</skip-advanced-fraud-checking>", xml);
            TestHelper.AssertIncludes("<skip-avs>true</skip-avs>", xml);
            TestHelper.AssertIncludes("<skip-cvv>true</skip-cvv>", xml);
            TestHelper.AssertIncludes("<three-d-secure><required>true</required></three-d-secure>", xml);
            TestHelper.AssertIncludes("<paypal><payee-id>paypal-payee-id</payee-id></paypal>", xml);
            TestHelper.AssertIncludes("<venmo><profile-id>venmo-profile-id</profile-id></venmo>", xml);
            TestHelper.AssertIncludes("<processing-overrides><customer-email>customer@example.com</customer-email></processing-overrides>", xml);
        }
    }
}
