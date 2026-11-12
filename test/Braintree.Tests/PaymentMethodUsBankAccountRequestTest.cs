using System;
using NUnit.Framework;
using Braintree.TestUtil;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodUsBankAccountRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new PaymentMethodUsBankAccountRequest(new PaymentMethodRequest())
                .AchMandateText("some-mandate-text")
                .AchMandateAcceptedAt(new DateTime(2020, 1, 1));

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<achMandateText>some-mandate-text</achMandateText>", xml);
            TestHelper.AssertIncludes("<achMandateAcceptedAt type=\"datetime\">2020-01-01 00:00:00Z</achMandateAcceptedAt>", xml);
        }
    }
}
