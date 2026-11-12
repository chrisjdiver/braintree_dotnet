using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class BinDataTest
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
            string xml = "<bin-data>" +
                "<country-of-issuance>USA</country-of-issuance>" +
                "<issuing-bank>Issuer</issuing-bank>" +
                "<product-id>prod-1</product-id>" +
                "<business>No</business>" +
                "<commercial>Yes</commercial>" +
                "<consumer>No</consumer>" +
                "<corporate>No</corporate>" +
                "<debit>Yes</debit>" +
                "<durbin-regulated>No</durbin-regulated>" +
                "<healthcare>No</healthcare>" +
                "<payroll>No</payroll>" +
                "<prepaid>No</prepaid>" +
                "<prepaid-reloadable>No</prepaid-reloadable>" +
                "<purchase>Yes</purchase>" +
            "</bin-data>";
            var node = nodeFromXml(xml);

            BinData binData = new BinData(node);

            Assert.AreEqual("USA", binData.CountryOfIssuance);
            Assert.AreEqual("Issuer", binData.IssuingBank);
            Assert.AreEqual("prod-1", binData.ProductId);
            Assert.AreEqual(CreditCardBusiness.NO, binData.Business);
            Assert.AreEqual(CreditCardCommercial.YES, binData.Commercial);
            Assert.AreEqual(CreditCardConsumer.NO, binData.Consumer);
            Assert.AreEqual(CreditCardCorporate.NO, binData.Corporate);
            Assert.AreEqual(CreditCardDebit.YES, binData.Debit);
            Assert.AreEqual(CreditCardDurbinRegulated.NO, binData.DurbinRegulated);
            Assert.AreEqual(CreditCardHealthcare.NO, binData.Healthcare);
            Assert.AreEqual(CreditCardPayroll.NO, binData.Payroll);
            Assert.AreEqual(CreditCardPrepaid.NO, binData.Prepaid);
            Assert.AreEqual(CreditCardPrepaidReloadable.NO, binData.PrepaidReloadable);
            Assert.AreEqual(CreditCardPurchase.YES, binData.Purchase);
        }
    }
}
