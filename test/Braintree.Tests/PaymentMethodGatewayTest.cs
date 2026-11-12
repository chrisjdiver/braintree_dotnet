using Braintree.Exceptions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Braintree.Tests
{
    [TestFixture]
    public class PaymentMethodGatewayTest
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
        public void Find_InvalidTokenThrowsNotFoundException()
        {
            foreach (var token in InvalidTokens)
            {
                Assert.Throws<NotFoundException>(() => gateway.PaymentMethod.Find(token));
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
                    await gateway.PaymentMethod.FindAsync(token);
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
                Assert.Throws<NotFoundException>(() => gateway.PaymentMethod.Update(token, new PaymentMethodRequest()));
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
                    await gateway.PaymentMethod.UpdateAsync(token, new PaymentMethodRequest());
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
                Assert.Throws<NotFoundException>(() => gateway.PaymentMethod.Delete(token));
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
                    await gateway.PaymentMethod.DeleteAsync(token);
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
        public void DeleteWithRequest_InvalidTokenThrowsNotFoundException()
        {
            foreach (var token in InvalidTokens)
            {
                Assert.Throws<NotFoundException>(() => gateway.PaymentMethod.Delete(token, new PaymentMethodDeleteRequest()));
            }
        }
    }
}
