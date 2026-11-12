using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class UnknownPaymentMethodTest
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
            string xml = "<payment-method>" +
                "<token>pm_token</token>" +
                "<default>true</default>" +
                "<customer-id>cust_id</customer-id>" +
                "</payment-method>";
            var node = nodeFromXml(xml);

            UnknownPaymentMethod paymentMethod = new UnknownPaymentMethod(node);

            Assert.AreEqual("pm_token", paymentMethod.Token);
            Assert.AreEqual(true, paymentMethod.IsDefault);
            Assert.AreEqual("cust_id", paymentMethod.CustomerId);
            Assert.AreEqual("https://assets.braintreegateway.com/payment_method_logo/unknown.png", paymentMethod.ImageUrl);
        }
    }
}
