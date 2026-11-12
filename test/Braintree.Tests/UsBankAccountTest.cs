using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class UsBankAccountTest
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
                "<customer-id>cust_id</customer-id>" +
                "<ach-mandate><text>mandate text</text><accepted-at>2024-01-01T00:00:00Z</accepted-at></ach-mandate>" +
                "<default>true</default>" +
                "<verified>true</verified>" +
                "</us-bank-account>";
            var node = nodeFromXml(xml);

            UsBankAccount account = new UsBankAccount(node);

            Assert.AreEqual("123456789", account.RoutingNumber);
            Assert.AreEqual("1234", account.Last4);
            Assert.AreEqual("checking", account.AccountType);
            Assert.AreEqual("John Doe", account.AccountHolderName);
            Assert.AreEqual("bank_token", account.Token);
            Assert.AreEqual("https://example.com/image.png", account.ImageUrl);
            Assert.AreEqual("Example Bank", account.BankName);
            Assert.AreEqual("cust_id", account.CustomerId);
            Assert.AreEqual("mandate text", account.AchMandate.Text);
            Assert.AreEqual(true, account.IsDefault);
            Assert.AreEqual(true, account.IsVerified);
        }
    }
}
