using Braintree.Exceptions;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class UsBankAccountGatewayTest
    {
        private BraintreeGateway gateway;
        private UsBankAccountGateway usBankAccountGateway;

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
            usBankAccountGateway = new UsBankAccountGateway(gateway);
        }

        [Test]
        public void Find_InvalidTokenThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => usBankAccountGateway.Find("../customers/victim"));
        }
    }
}
