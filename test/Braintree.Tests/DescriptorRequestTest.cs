using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class DescriptorRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new DescriptorRequest
            {
                Name = "companyname*productname",
                Phone = "3334445555",
                Url = "ebay.com"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<name>companyname*productname</name>", xml);
            TestHelper.AssertIncludes("<phone>3334445555</phone>", xml);
            TestHelper.AssertIncludes("<url>ebay.com</url>", xml);
        }
    }
}
