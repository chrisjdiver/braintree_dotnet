using Braintree.Exceptions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Braintree.Tests
{
    [TestFixture]
    public class CreditCardGatewayTest
    {
        private BraintreeGateway gateway;

        private static readonly string[] InvalidTokens = { null, "", ".", "../payment_methods/any/victim" };

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
        public void Find_InvalidTokenThrowsNotFoundException()
        {
            foreach (var token in InvalidTokens)
            {
                Assert.Throws<NotFoundException>(() => gateway.CreditCard.Find(token));
            }
        }

        [Test]
#if netcore
        public async Task FindAsync_InvalidTokenThrowsNotFoundExceptionAsync()
#else
        public void FindAsync_InvalidTokenThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var token in InvalidTokens)
            {
                try
                {
                    await gateway.CreditCard.FindAsync(token);
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
        public void FromNonce_InvalidNonceThrowsNotFoundException()
        {
            foreach (var nonce in InvalidTokens)
            {
                Assert.Throws<NotFoundException>(() => gateway.CreditCard.FromNonce(nonce));
            }
        }

        [Test]
#if netcore
        public async Task FromNonceAsync_InvalidNonceThrowsNotFoundExceptionAsync()
#else
        public void FromNonceAsync_InvalidNonceThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var nonce in InvalidTokens)
            {
                try
                {
                    await gateway.CreditCard.FromNonceAsync(nonce);
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
        public void Delete_InvalidTokenThrowsNotFoundException()
        {
            foreach (var token in InvalidTokens)
            {
                Assert.Throws<NotFoundException>(() => gateway.CreditCard.Delete(token));
            }
        }

        [Test]
#if netcore
        public async Task DeleteAsync_InvalidTokenThrowsNotFoundExceptionAsync()
#else
        public void DeleteAsync_InvalidTokenThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var token in InvalidTokens)
            {
                try
                {
                    await gateway.CreditCard.DeleteAsync(token);
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
        public void Update_InvalidTokenThrowsNotFoundException()
        {
            foreach (var token in InvalidTokens)
            {
                Assert.Throws<NotFoundException>(() => gateway.CreditCard.Update(token, new CreditCardRequest()));
            }
        }

        [Test]
#if netcore
        public async Task UpdateAsync_InvalidTokenThrowsNotFoundExceptionAsync()
#else
        public void UpdateAsync_InvalidTokenThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var token in InvalidTokens)
            {
                try
                {
                    await gateway.CreditCard.UpdateAsync(token, new CreditCardRequest());
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
