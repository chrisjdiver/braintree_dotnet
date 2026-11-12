using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class IdsSearchRequestTest
    {
        [Test]
        public void ToXml_IdsIncludedIn()
        {
            IdsSearchRequest request = new IdsSearchRequest().Ids.IncludedIn("abc", "def");
            var xml = "<search><ids type=\"array\"><item>abc</item><item>def</item></ids></search>";
            Assert.AreEqual(xml, request.ToXml());
        }

        [Test]
        public void ToXml_IdsIs()
        {
            IdsSearchRequest request = new IdsSearchRequest().Ids.Is("abc");
            var xml = "<search><ids type=\"array\"><item>abc</item></ids></search>";
            Assert.AreEqual(xml, request.ToXml());
        }
    }
}
