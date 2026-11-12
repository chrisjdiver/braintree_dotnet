using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class VenmoProfileDataTest
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
            string xml = "<venmo-profile-data>" +
                "<username>venmojoe</username>" +
                "<first-name>Joe</first-name>" +
                "<last-name>Doe</last-name>" +
                "<phone-number>3334445555</phone-number>" +
                "<email>joe@example.com</email>" +
                "<billing-address><street-address>1 Billing St</street-address></billing-address>" +
                "<shipping-address><street-address>1 Shipping St</street-address></shipping-address>" +
                "</venmo-profile-data>";
            var node = nodeFromXml(xml);

            VenmoProfileData profileData = new VenmoProfileData(node);

            Assert.AreEqual("venmojoe", profileData.Username);
            Assert.AreEqual("Joe", profileData.FirstName);
            Assert.AreEqual("Doe", profileData.LastName);
            Assert.AreEqual("3334445555", profileData.PhoneNumber);
            Assert.AreEqual("joe@example.com", profileData.Email);
            Assert.AreEqual("1 Billing St", profileData.BillingAddress.StreetAddress);
            Assert.AreEqual("1 Shipping St", profileData.ShippingAddress.StreetAddress);
        }
    }
}
