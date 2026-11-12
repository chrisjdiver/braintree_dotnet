using Braintree.Exceptions;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class ThreeDSecureGatewayTest
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
        public void Lookup_TraversalNonceThrowsNotFoundException()
        {
            var request = new ThreeDSecureLookupRequest
            {
                Nonce = "../customers/victim",
                Amount = "10.00"
            };

            Assert.Throws<NotFoundException>(() => gateway.ThreeDSecure.Lookup(request));
        }
    }
}
