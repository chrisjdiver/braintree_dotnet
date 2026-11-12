using NUnit.Framework;
using Braintree.TestUtil;
using System;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionUsBankAccountRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new TransactionUsBankAccountRequest(new TransactionRequest())
                .AchMandateText("mandate text")
                .AchMandateAcceptedAt(new DateTime(2024, 1, 1));

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<achMandateText>mandate text</achMandateText>", xml);
            TestHelper.AssertIncludes("<achMandateAcceptedAt type=\"datetime\">2024-01-01 00:00:00Z</achMandateAcceptedAt>", xml);
        }
    }
}
