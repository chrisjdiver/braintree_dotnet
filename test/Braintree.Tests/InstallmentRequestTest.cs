using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class InstallmentRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new InstallmentRequest
            {
                Count = "4"
            };

            string xml = request.ToXml("installments");

            TestHelper.AssertIncludes("<count>4</count>", xml);
        }
    }
}
