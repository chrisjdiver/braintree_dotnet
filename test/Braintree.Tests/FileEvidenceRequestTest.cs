using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class FileEvidenceRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new FileEvidenceRequest
            {
                DocumentId = "document_id",
                Category = "GENERAL"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<evidence>", xml);
            TestHelper.AssertIncludes("<document-upload-id>document_id</document-upload-id>", xml);
            TestHelper.AssertIncludes("<category>GENERAL</category>", xml);
        }

        [Test]
        public void ToQueryString_IncludesAllData()
        {
            var request = new FileEvidenceRequest
            {
                DocumentId = "document_id",
                Category = "GENERAL"
            };

            string queryString = request.ToQueryString();

            TestHelper.AssertIncludes("evidence%5Bdocument_upload_id%5D=document_id", queryString);
            TestHelper.AssertIncludes("evidence%5Bcategory%5D=GENERAL", queryString);
        }
    }
}
