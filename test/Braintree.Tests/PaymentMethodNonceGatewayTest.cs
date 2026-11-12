using Braintree.Exceptions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodNonceGatewayTest
    {
        private BraintreeGateway gateway;

        private static readonly string[] InvalidTokens = { null, "", ".", "../customers/victim" };

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
        public void Create_InvalidTokenThrowsNotFoundException()
        {
            foreach (var token in InvalidTokens)
            {
                Assert.Throws<NotFoundException>(() => gateway.PaymentMethodNonce.Create(token));
            }
        }

        [Test]
#if netcore
        public async Task CreateAsync_InvalidTokenThrowsNotFoundExceptionAsync()
#else
        public void CreateAsync_InvalidTokenThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var token in InvalidTokens)
            {
                try
                {
                    await gateway.PaymentMethodNonce.CreateAsync(token);
                    Assert.Fail("Expected NotFoundException.");
                }
                catch (NotFoundException)
                {
                }
            }
        }
#if net452
            ).GetAwaiter().GetResult();
        }
#endif

        [Test]
        public void Find_InvalidNonceThrowsNotFoundException()
        {
            foreach (var nonce in InvalidTokens)
            {
                Assert.Throws<NotFoundException>(() => gateway.PaymentMethodNonce.Find(nonce));
            }
        }

        [Test]
#if netcore
        public async Task FindAsync_InvalidNonceThrowsNotFoundExceptionAsync()
#else
        public void FindAsync_InvalidNonceThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var nonce in InvalidTokens)
            {
                try
                {
                    await gateway.PaymentMethodNonce.FindAsync(nonce);
                    Assert.Fail("Expected NotFoundException.");
                }
                catch (NotFoundException)
                {
                }
            }
        }
#if net452
            ).GetAwaiter().GetResult();
        }
#endif
    }
}
