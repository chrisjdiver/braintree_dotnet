using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class DisbursementDetailsTest
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
            string xml = "<disbursement-details>" +
                "<settlement-amount>100.00</settlement-amount>" +
                "<settlement-currency-iso-code>USD</settlement-currency-iso-code>" +
                "<settlement-currency-exchange-rate>1.0</settlement-currency-exchange-rate>" +
                "<funds-held type=\"boolean\">false</funds-held>" +
                "<success type=\"boolean\">true</success>" +
                "<disbursement-date type=\"date\">2018-05-15</disbursement-date>" +
            "</disbursement-details>";
            var node = nodeFromXml(xml);

            DisbursementDetails details = new DisbursementDetails(node);

            Assert.AreEqual(100.00M, details.SettlementAmount);
            Assert.AreEqual("USD", details.SettlementCurrencyIsoCode);
            Assert.AreEqual("1.0", details.SettlementCurrencyExchangeRate);
            Assert.AreEqual(false, details.FundsHeld);
            Assert.AreEqual(true, details.Success);
            Assert.AreEqual(true, details.IsValid());
        }
    }
}
