using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class EnrichedCustomerDataTest
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
            string xml = "<enriched-customer-data>" +
                "<fields-updated type=\"array\">" +
                    "<item>username</item>" +
                    "<item>first-name</item>" +
                "</fields-updated>" +
                "<profile-data>" +
                    "<username>venmo-user</username>" +
                    "<first-name>First</first-name>" +
                    "<last-name>Last</last-name>" +
                    "<phone-number>1234567890</phone-number>" +
                    "<email>user@example.com</email>" +
                "</profile-data>" +
            "</enriched-customer-data>";
            var node = nodeFromXml(xml);

            EnrichedCustomerData data = new EnrichedCustomerData(node);

            Assert.AreEqual(2, data.FieldsUpdated.Count);
            Assert.AreEqual("username", data.FieldsUpdated[0]);
            Assert.AreEqual("first-name", data.FieldsUpdated[1]);
            Assert.AreEqual("venmo-user", data.ProfileData.Username);
            Assert.AreEqual("First", data.ProfileData.FirstName);
            Assert.AreEqual("Last", data.ProfileData.LastName);
            Assert.AreEqual("user@example.com", data.ProfileData.Email);
        }
    }
}
