using Braintree.Exceptions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Braintree.Tests
{
    [TestFixture]
    public class TestTransactionGatewayTest
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
        public void Settle_InvalidIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.TestTransaction.Settle("../transactions/victim"));
        }

        [Test]
        public void SettlementConfirm_InvalidIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.TestTransaction.SettlementConfirm("../transactions/victim"));
        }

        [Test]
        public void SettlementPending_InvalidIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.TestTransaction.SettlementPending("../transactions/victim"));
        }

        [Test]
        public void SettlementDecline_InvalidIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.TestTransaction.SettlementDecline("../transactions/victim"));
        }

        [Test]
        public void Settle_InvalidIdInProductionThrowsNotFoundExceptionNotEnvironmentException()
        {
            var productionGateway = new BraintreeGateway
            {
                Environment = Environment.PRODUCTION,
                MerchantId = "integration_merchant_id",
                PublicKey = "integration_public_key",
                PrivateKey = "integration_private_key"
            };

            Assert.Throws<NotFoundException>(() => productionGateway.TestTransaction.Settle("../transactions/victim"));
        }

        [Test]
#if netcore
        public async Task SettleAsync_InvalidIdInProductionThrowsNotFoundExceptionNotEnvironmentExceptionAsync()
#else
        public void SettleAsync_InvalidIdInProductionThrowsNotFoundExceptionNotEnvironmentExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            var productionGateway = new BraintreeGateway
            {
                Environment = Environment.PRODUCTION,
                MerchantId = "integration_merchant_id",
                PublicKey = "integration_public_key",
                PrivateKey = "integration_private_key"
            };

            try
            {
                await productionGateway.TestTransaction.SettleAsync("../transactions/victim");
                Assert.Fail("Expected NotFoundException.");
            }
            catch (NotFoundException)
            {
            }
        }
#if net452
            ).GetAwaiter().GetResult();
        }
#endif
    }
}