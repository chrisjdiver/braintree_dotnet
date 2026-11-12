using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class CustomerSearchRequestTest
    {
        [Test]
        public void ToXml_IdIs()
        {
            CustomerSearchRequest request = new CustomerSearchRequest().Id.Is("30");
            var xml = "<search><id><is>30</is></id></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_CardholderNameIs()
        {
            CustomerSearchRequest request = new CustomerSearchRequest().CardholderName.Is("Jane Doe");
            var xml = "<search><cardholder-name><is>Jane Doe</is></cardholder-name></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_EmailIs()
        {
            CustomerSearchRequest request = new CustomerSearchRequest().Email.Is("jane@example.com");
            var xml = "<search><email><is>jane@example.com</is></email></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_FirstNameIs()
        {
            CustomerSearchRequest request = new CustomerSearchRequest().FirstName.Is("Jane");
            var xml = "<search><first-name><is>Jane</is></first-name></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_LastNameIs()
        {
            CustomerSearchRequest request = new CustomerSearchRequest().LastName.Is("Doe");
            var xml = "<search><last-name><is>Doe</is></last-name></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_IdsIncludedIn()
        {
            CustomerSearchRequest request = new CustomerSearchRequest().Ids.IncludedIn("abc", "def");
            var xml = "<search><ids type=\"array\"><item>abc</item><item>def</item></ids></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_CreditCardExpirationDateIs()
        {
            CustomerSearchRequest request = new CustomerSearchRequest().CreditCardExpirationDate.Is("05/2020");
            var xml = "<search><credit-card-expiration-date><is>05/2020</is></credit-card-expiration-date></search>";
            Assert.AreEqual(xml, request.ToXml());
        }
    }
}
