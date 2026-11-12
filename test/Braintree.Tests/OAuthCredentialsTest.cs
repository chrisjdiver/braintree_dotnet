using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class OAuthCredentialsTest
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
            string xml = "<credentials>" +
                "<access-token>access-token-value</access-token>" +
                "<refresh-token>refresh-token-value</refresh-token>" +
                "<token-type>bearer</token-type>" +
                "<scope>read_write</scope>" +
                "<expires-at>2019-01-01T00:00:00Z</expires-at>" +
            "</credentials>";
            var node = nodeFromXml(xml);

            OAuthCredentials credentials = new OAuthCredentials(node);

            Assert.AreEqual("access-token-value", credentials.AccessToken);
            Assert.AreEqual("refresh-token-value", credentials.RefreshToken);
            Assert.AreEqual("bearer", credentials.TokenType);
            Assert.AreEqual("read_write", credentials.Scope);
        }
    }
}
