using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class InternationalPhoneTest
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
            string xml = "<international-phone>" +
                "<country-code>1</country-code>" +
                "<national-number>3121234567</national-number>" +
            "</international-phone>";
            var node = nodeFromXml(xml);

            InternationalPhone phone = new InternationalPhone(node);

            Assert.AreEqual("1", phone.CountryCode);
            Assert.AreEqual("3121234567", phone.NationalNumber);
        }
    }
}
