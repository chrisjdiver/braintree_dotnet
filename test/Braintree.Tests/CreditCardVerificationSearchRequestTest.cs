using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class CreditCardVerificationSearchRequestTest
    {
        [Test]
        public void ToXml_IdIs()
        {
            CreditCardVerificationSearchRequest request = new CreditCardVerificationSearchRequest().Id.Is("30");
            var xml = "<search><id><is>30</is></id></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_CreditCardCardholderNameIs()
        {
            CreditCardVerificationSearchRequest request = new CreditCardVerificationSearchRequest().CreditCardCardholderName.Is("Jane Doe");
            var xml = "<search><credit-card-cardholder-name><is>Jane Doe</is></credit-card-cardholder-name></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_CreditCardExpirationDateIs()
        {
            CreditCardVerificationSearchRequest request = new CreditCardVerificationSearchRequest().CreditCardExpirationDate.Is("05/2020");
            var xml = "<search><credit-card-expiration-date><is>05/2020</is></credit-card-expiration-date></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_IdsIncludedIn()
        {
            CreditCardVerificationSearchRequest request = new CreditCardVerificationSearchRequest().Ids.IncludedIn("abc", "def");
            var xml = "<search><ids type=\"array\"><item>abc</item><item>def</item></ids></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_PaymentMethodTokenIs()
        {
            CreditCardVerificationSearchRequest request = new CreditCardVerificationSearchRequest().PaymentMethodToken.Is("token");
            var xml = "<search><payment-method-token><is>token</is></payment-method-token></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_CustomerEmailIs()
        {
            CreditCardVerificationSearchRequest request = new CreditCardVerificationSearchRequest().CustomerEmail.Is("jane@example.com");
            var xml = "<search><customer-email><is>jane@example.com</is></customer-email></search>";
            Assert.AreEqual(xml, request.ToXml());
        }
    }
}
