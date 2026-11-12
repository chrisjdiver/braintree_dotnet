using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class PayPalHereDetailsTest
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
            string xml = "<paypal-here>" +
                "<authorization-id>AUTH-1234</authorization-id>" +
                "<capture-id>CAP-1234</capture-id>" +
                "<invoice-id>INV-1234</invoice-id>" +
                "<last-4>1234</last-4>" +
                "<payment-id>PAY-1234</payment-id>" +
                "<payment-type>credit</payment-type>" +
                "<refund-id>REF-1234</refund-id>" +
                "<transaction-fee-amount>1.50</transaction-fee-amount>" +
                "<transaction-fee-currency-iso-code>USD</transaction-fee-currency-iso-code>" +
                "<transaction-initiation-date>2021-01-01T00:00:00Z</transaction-initiation-date>" +
                "<transaction-updated-date>2021-01-02T00:00:00Z</transaction-updated-date>" +
                "</paypal-here>";
            var node = nodeFromXml(xml);

            PayPalHereDetails details = new PayPalHereDetails(node);

            Assert.AreEqual("AUTH-1234", details.AuthorizationId);
            Assert.AreEqual("CAP-1234", details.CaptureId);
            Assert.AreEqual("INV-1234", details.InvoiceId);
            Assert.AreEqual("1234", details.Last4);
            Assert.AreEqual("PAY-1234", details.PaymentId);
            Assert.AreEqual("credit", details.PaymentType);
            Assert.AreEqual("REF-1234", details.RefundId);
            Assert.AreEqual("1.50", details.TransactionFeeAmount);
            Assert.AreEqual("USD", details.TransactionFeeCurrencyIsoCode);
            Assert.AreEqual("2021-01-01T00:00:00Z", details.TransactionInitiationDate);
            Assert.AreEqual("2021-01-02T00:00:00Z", details.TransactionUpdatedDate);
        }
    }
}
