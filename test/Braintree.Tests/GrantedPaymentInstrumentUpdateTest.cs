using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class GrantedPaymentInstrumentUpdateTest
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
            string xml = "<granted-payment-instrument-update>" +
                "<payment-method-nonce>" +
                    "<nonce>a-nonce</nonce>" +
                "</payment-method-nonce>" +
                "<grant-owner-merchant-id>owner-merchant</grant-owner-merchant-id>" +
                "<grant-recipient-merchant-id>recipient-merchant</grant-recipient-merchant-id>" +
                "<token>token-123</token>" +
                "<updated-fields type=\"array\">" +
                    "<item>expiration-month</item>" +
                    "<item>expiration-year</item>" +
                "</updated-fields>" +
            "</granted-payment-instrument-update>";
            var node = nodeFromXml(xml);

            GrantedPaymentInstrumentUpdate update = new GrantedPaymentInstrumentUpdate(node);

            Assert.AreEqual("a-nonce", update.PaymentMethodNonce);
            Assert.AreEqual("owner-merchant", update.GrantOwnerMerchantId);
            Assert.AreEqual("recipient-merchant", update.GrantRecipientMerchantId);
            Assert.AreEqual("token-123", update.Token);
            Assert.AreEqual(2, update.UpdatedFields.Count);
            Assert.AreEqual("expiration-month", update.UpdatedFields[0]);
            Assert.AreEqual("expiration-year", update.UpdatedFields[1]);
        }
    }
}
