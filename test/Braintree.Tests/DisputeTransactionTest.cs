using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class DisputeTransactionTest
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
            string xml = "<transaction>" +
                "<amount>25.00</amount>" +
                "<created-at>2019-01-01T00:00:00Z</created-at>" +
                "<id>transaction-id</id>" +
                "<installment-count>4</installment-count>" +
                "<order-id>order-123</order-id>" +
                "<payment-instrument-subtype>Visa</payment-instrument-subtype>" +
                "<purchase-order-number>po-456</purchase-order-number>" +
            "</transaction>";
            var node = nodeFromXml(xml);

            DisputeTransaction transaction = new DisputeTransaction(node);

            Assert.AreEqual(25.00M, transaction.Amount);
            Assert.AreEqual("transaction-id", transaction.Id);
            Assert.AreEqual(4, transaction.InstallmentCount);
            Assert.AreEqual("order-123", transaction.OrderId);
            Assert.AreEqual("Visa", transaction.PaymentInstrumentSubtype);
            Assert.AreEqual("po-456", transaction.PurchaseOrderNumber);
        }
    }
}
