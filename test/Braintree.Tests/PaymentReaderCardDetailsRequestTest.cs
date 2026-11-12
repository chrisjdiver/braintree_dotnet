using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentReaderCardDetailsRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PaymentReaderCardDetailsRequest
            {
                EncryptedCardData = "some-encrypted-card-data",
                KeySerialNumber = "some-key-serial-number"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<encrypted-card-data>some-encrypted-card-data</encrypted-card-data>", xml);
            TestHelper.AssertIncludes("<key-serial-number>some-key-serial-number</key-serial-number>", xml);
        }
    }
}
