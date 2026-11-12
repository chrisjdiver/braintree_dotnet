using Braintree.Exceptions;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class UsBankAccountVerificationGatewayTest
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
        public void Find_InvalidIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.UsBankAccountVerification.Find("../transactions/victim"));
        }

        [Test]
        public void ConfirmMicroTransferAmounts_InvalidIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.UsBankAccountVerification.ConfirmMicroTransferAmounts("../transactions/victim", new UsBankAccountVerificationConfirmRequest()));
        }
    }
}
