using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class UsBankAccountDetailsTest
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
            string xml = "<us-bank-account>" +
                "<routing-number>123456789</routing-number>" +
                "<last-4>1234</last-4>" +
                "<account-type>checking</account-type>" +
                "<account-holder-name>John Doe</account-holder-name>" +
                "<token>bank_token</token>" +
                "<image-url>https://example.com/image.png</image-url>" +
                "<bank-name>Example Bank</bank-name>" +
                "<ach-mandate><text>mandate text</text><accepted-at>2024-01-01T00:00:00Z</accepted-at></ach-mandate>" +
                "</us-bank-account>";
            var node = nodeFromXml(xml);

            UsBankAccountDetails details = new UsBankAccountDetails(node);

            Assert.AreEqual("123456789", details.RoutingNumber);
            Assert.AreEqual("1234", details.Last4);
            Assert.AreEqual("checking", details.AccountType);
            Assert.AreEqual("John Doe", details.AccountHolderName);
            Assert.AreEqual("bank_token", details.Token);
            Assert.AreEqual("https://example.com/image.png", details.ImageUrl);
            Assert.AreEqual("Example Bank", details.BankName);
            Assert.AreEqual("mandate text", details.AchMandate.Text);
        }
    }
}
