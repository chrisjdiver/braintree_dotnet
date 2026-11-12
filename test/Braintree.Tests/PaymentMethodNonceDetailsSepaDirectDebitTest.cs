using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodNonceDetailsSepaDirectDebitTest
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
            string xml = "<sepa-direct-debit>" +
                "<bank-reference-token>QkFOSw==</bank-reference-token>" +
                "<correlation-id>corr-123</correlation-id>" +
                "<iban-last-chars>1234</iban-last-chars>" +
                "<mandate-type>one_off</mandate-type>" +
                "<merchant-or-partner-customer-id>cust-456</merchant-or-partner-customer-id>" +
                "</sepa-direct-debit>";
            var node = nodeFromXml(xml);

            PaymentMethodNonceDetailsSepaDirectDebit sepa = new PaymentMethodNonceDetailsSepaDirectDebit(node);

            Assert.AreEqual("QkFOSw==", sepa.BankReferenceToken);
            Assert.AreEqual("corr-123", sepa.CorrelationId);
            Assert.AreEqual("1234", sepa.IbanLastChars);
            Assert.AreEqual(MandateType.ONE_OFF, sepa.MandateType);
            Assert.AreEqual("cust-456", sepa.MerchantOrPartnerCustomerId);
        }
    }
}
