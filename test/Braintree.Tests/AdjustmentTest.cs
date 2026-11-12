using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class AdjustmentTest
    {
        private NodeWrapper nodeFromXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return new NodeWrapper(doc.DocumentElement);
        }

        [Test]
        public void IncludesFields()
        {
            string xml = "<adjustment>" +
                "<amount>12.34</amount>" +
                "<projected_disbursement_date type=\"date\">2018-05-15</projected_disbursement_date>" +
                "<actual_disbursement_date type=\"date\">2018-05-16</actual_disbursement_date>" +
                "<kind>refund</kind>" +
            "</adjustment>";
            var node = nodeFromXml(xml);

            Adjustment adjustment = new Adjustment(node);

            Assert.AreEqual(12.34M, adjustment.Amount);
            Assert.AreEqual(Kind.REFUND, adjustment.Kind);
        }
    }
}
