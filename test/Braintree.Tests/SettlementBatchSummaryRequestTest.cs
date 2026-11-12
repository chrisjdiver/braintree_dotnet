using NUnit.Framework;
using Braintree.TestUtil;
using System;

namespace Braintree.Tests
{
    [TestFixture]
    public class SettlementBatchSummaryRequestTest
    {
        [Test]
        public void ToXml_IncludesAllData()
        {
            var request = new SettlementBatchSummaryRequest
            {
                SettlementDate = new DateTime(2020, 1, 15),
                GroupByCustomField = "my_custom_field"
            };

            string xml = request.ToXml();

            TestHelper.AssertIncludes("<settlement-date>1/15/2020</settlement-date>", xml);
            TestHelper.AssertIncludes("<group-by-custom-field>my_custom_field</group-by-custom-field>", xml);
        }
    }
}
