using Braintree.Exceptions;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionLineItemGatewayTest
    {
        private BraintreeGateway gateway;

        [SetUp]
        public void Setup()
        {
            gateway = new BraintreeGateway
            {
                Environment = Environment.DEVELOPMENT,
                MerchantId = "integration_merchant_id",
                PublicKey = "integration_public_key",
                PrivateKey = "integration_private_key"
            };
        }

        [Test]
        public void FindAll_InvalidIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.TransactionLineItem.FindAll("../transactions/victim"));
        }
    }
}
