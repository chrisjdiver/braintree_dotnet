using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionReverseRequestTest
    {
        [Test]
        public void ToXml_IncludesApiRequestKey()
        {
            var request = new TransactionReverseRequest { ApiRequestKey = "reverse-key-789" };

            Assert.IsTrue(request.ToXml().Contains("<api-request-key>reverse-key-789</api-request-key>"));
        }

        [Test]
        public void ToXml_ExcludesApiRequestKeyWhenNull()
        {
            var request = new TransactionReverseRequest { ApiRequestKey = null };

            Assert.IsFalse(request.ToXml().Contains("api-request-key"));
        }

        [Test]
        public void ToXml_EmptyRequestCreatesMinimalXml()
        {
            string xml = new TransactionReverseRequest().ToXml();

            Assert.IsTrue(xml.Contains("<transaction>"));
            Assert.IsTrue(xml.Contains("</transaction>"));
            Assert.IsFalse(xml.Contains("api-request-key"));
        }
    }
}
