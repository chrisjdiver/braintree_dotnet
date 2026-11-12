using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class RecipientPhoneDetailsTest
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
            string xml = "<recipient-phone>" +
                "<country-code>1</country-code>" +
                "<national-number>5551234567</national-number>" +
                "</recipient-phone>";
            var node = nodeFromXml(xml);

            RecipientPhoneDetails details = new RecipientPhoneDetails(node);

            Assert.AreEqual("1", details.CountryCode);
            Assert.AreEqual("5551234567", details.NationalNumber);
        }
    }
}
