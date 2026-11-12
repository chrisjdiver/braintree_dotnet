using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class PartnerMerchantTest
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
            string xml = "<partner-merchant>" +
                "<merchant-public-id>public_id</merchant-public-id>" +
                "<public-key>public_key</public-key>" +
                "<private-key>private_key</private-key>" +
                "<partner-merchant-id>abc123</partner-merchant-id>" +
                "<client-side-encryption-key>cse_key</client-side-encryption-key>" +
                "</partner-merchant>";
            var node = nodeFromXml(xml);

            PartnerMerchant partnerMerchant = new PartnerMerchant(node);

            Assert.AreEqual("public_id", partnerMerchant.MerchantPublicId);
            Assert.AreEqual("public_key", partnerMerchant.PublicKey);
            Assert.AreEqual("private_key", partnerMerchant.PrivateKey);
            Assert.AreEqual("abc123", partnerMerchant.PartnerMerchantId);
            Assert.AreEqual("cse_key", partnerMerchant.ClientSideEncryptionKey);
        }
    }
}
