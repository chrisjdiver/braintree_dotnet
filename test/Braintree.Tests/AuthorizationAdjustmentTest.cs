using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class AuthorizationAdjustmentTest
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
            string xml = "<authorization-adjustment>" +
                "<amount>50.00</amount>" +
                "<success type=\"boolean\">true</success>" +
                "<timestamp type=\"datetime\">2018-05-15T12:00:00Z</timestamp>" +
                "<processor-response-code>1000</processor-response-code>" +
                "<processor-response-text>Approved</processor-response-text>" +
                "<processor-response-type>approved</processor-response-type>" +
            "</authorization-adjustment>";
            var node = nodeFromXml(xml);

            AuthorizationAdjustment adjustment = new AuthorizationAdjustment(node);

            Assert.AreEqual(50.00M, adjustment.Amount);
            Assert.AreEqual(true, adjustment.Success);
            Assert.AreEqual("1000", adjustment.ProcessorResponseCode);
            Assert.AreEqual("Approved", adjustment.ProcessorResponseText);
            Assert.AreEqual(ProcessorResponseType.APPROVED, adjustment.ProcessorResponseType);
        }
    }
}
