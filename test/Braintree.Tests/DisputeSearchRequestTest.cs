using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class DisputeSearchRequestTest
    {
        [Test]
        public void ToXml_IdIs()
        {
            DisputeSearchRequest request = new DisputeSearchRequest().Id.Is("30");
            var xml = "<search><id><is>30</is></id></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_CaseNumberIs()
        {
            DisputeSearchRequest request = new DisputeSearchRequest().CaseNumber.Is("CASE-123");
            var xml = "<search><case_number><is>CASE-123</is></case_number></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_CustomerIdIs()
        {
            DisputeSearchRequest request = new DisputeSearchRequest().CustomerId.Is("customer-id");
            var xml = "<search><customer_id><is>customer-id</is></customer_id></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_TransactionIdIs()
        {
            DisputeSearchRequest request = new DisputeSearchRequest().TransactionId.Is("transaction-id");
            var xml = "<search><transaction_id><is>transaction-id</is></transaction_id></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_ReferenceNumberIs()
        {
            DisputeSearchRequest request = new DisputeSearchRequest().ReferenceNumber.Is("ref-123");
            var xml = "<search><reference_number><is>ref-123</is></reference_number></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_MerchantAccountIdIncludedIn()
        {
            DisputeSearchRequest request = new DisputeSearchRequest().MerchantAccountId.IncludedIn("abc", "def");
            var xml = "<search><merchant_account_id type=\"array\"><item>abc</item><item>def</item></merchant_account_id></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_AmountDisputedBetween()
        {
            DisputeSearchRequest request = new DisputeSearchRequest().AmountDisputed.Between(1M, 2M);
            var xml = "<search><amount_disputed><min>1</min><max>2</max></amount_disputed></search>";
            Assert.AreEqual(xml, request.ToXml());
        }
    }
}
