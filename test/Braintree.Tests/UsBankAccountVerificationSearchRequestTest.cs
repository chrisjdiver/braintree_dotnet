using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class UsBankAccountVerificationSearchRequestTest
    {
        [Test]
        public void ToXml_IncludesTextNodes()
        {
            UsBankAccountVerificationSearchRequest searchRequest =
                new UsBankAccountVerificationSearchRequest().
                Id.Is("1234").
                AccountHolderName.Is("John Doe").
                RoutingNumber.Is("021000021").
                CustomerId.Is("customer-id").
                CustomerEmail.Is("customer@example.com").
                PaymentMethodToken.Is("token-value");

            string xml = searchRequest.ToXml();

            TestHelper.AssertIncludes("<id><is>1234</is></id>", xml);
            TestHelper.AssertIncludes("<account-holder-name><is>John Doe</is></account-holder-name>", xml);
            TestHelper.AssertIncludes("<routing-number><is>021000021</is></routing-number>", xml);
            TestHelper.AssertIncludes("<customer-id><is>customer-id</is></customer-id>", xml);
            TestHelper.AssertIncludes("<customer-email><is>customer@example.com</is></customer-email>", xml);
            TestHelper.AssertIncludes("<payment-method-token><is>token-value</is></payment-method-token>", xml);
        }

        [Test]
        public void ToXml_IncludesAccountNumberAndType()
        {
            UsBankAccountVerificationSearchRequest searchRequest =
                new UsBankAccountVerificationSearchRequest().
                AccountType.Is("checking");
            searchRequest.AccountNumber.EndsWith("1234");

            string xml = searchRequest.ToXml();

            TestHelper.AssertIncludes("<account-type><is>checking</is></account-type>", xml);
            TestHelper.AssertIncludes("<account-number><ends-with>1234</ends-with></account-number>", xml);
        }

        [Test]
        public void ToXml_IncludesMultiValueAndEnumNodes()
        {
            UsBankAccountVerificationSearchRequest searchRequest =
                new UsBankAccountVerificationSearchRequest().
                Ids.IncludedIn("1234", "5678").
                Status.IncludedIn(UsBankAccountVerificationStatus.PENDING).
                VerificationMethod.IncludedIn(UsBankAccountVerificationMethod.NETWORK_CHECK);

            string xml = searchRequest.ToXml();

            TestHelper.AssertIncludes("<ids type=\"array\"><item>1234</item><item>5678</item></ids>", xml);
            TestHelper.AssertIncludes("<status type=\"array\"><item>pending</item></status>", xml);
            TestHelper.AssertIncludes("<verification-method type=\"array\"><item>network_check</item></verification-method>", xml);
        }
    }
}
