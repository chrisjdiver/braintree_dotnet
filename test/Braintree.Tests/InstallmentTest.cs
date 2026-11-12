using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class InstallmentTest
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
            string xml = "<installment>" +
                "<amount>12.34</amount>" +
                "<id>installment-id</id>" +
                "<projected_disbursement_date>2019-01-01T00:00:00Z</projected_disbursement_date>" +
                "<actual_disbursement_date>2019-01-02T00:00:00Z</actual_disbursement_date>" +
                "<adjustments type=\"array\">" +
                    "<adjustment>" +
                        "<amount>1.00</amount>" +
                        "<kind>refund</kind>" +
                        "<projected_disbursement_date>2019-01-03T00:00:00Z</projected_disbursement_date>" +
                        "<actual_disbursement_date>2019-01-04T00:00:00Z</actual_disbursement_date>" +
                    "</adjustment>" +
                "</adjustments>" +
            "</installment>";
            var node = nodeFromXml(xml);

            Installment installment = new Installment(node);

            Assert.AreEqual(12.34M, installment.Amount);
            Assert.AreEqual("installment-id", installment.Id);
            Assert.AreEqual(1, installment.Adjustments.Count);
            Assert.AreEqual(1.00M, installment.Adjustments[0].Amount);
        }
    }
}
