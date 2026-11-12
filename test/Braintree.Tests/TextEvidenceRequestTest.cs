using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class TextEvidenceRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TextEvidenceRequest
            {
                Content = "v",
                Category = "v",
                SequenceNumber = "0"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<comments>v</comments>", xml);
            TestHelper.AssertIncludes("<category>v</category>", xml);
            TestHelper.AssertIncludes("<sequence-number>0</sequence-number>", xml);
        }

        [Test]
        public void ToQueryString_IncludesAllData()
        {
            var request = new TextEvidenceRequest
            {
                Content = "v",
                Category = "v",
                SequenceNumber = "0"
            };

            string queryString = request.ToQueryString();

            TestHelper.AssertIncludes("evidence%5Bcomments%5D=v", queryString);
            TestHelper.AssertIncludes("evidence%5Bcategory%5D=v", queryString);
            TestHelper.AssertIncludes("evidence%5Bsequence_number%5D=0", queryString);
        }
    }
}
