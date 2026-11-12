using Braintree.Exceptions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Braintree.Tests
{
    [TestFixture]
    public class SubscriptionGatewayTest
    {
        private BraintreeGateway gateway;

        private static readonly string[] InvalidIds = { null, "", ".", "../transactions/victim" };

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
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Subscription.Find(id));
            }
        }

        [Test]
#if netcore
        public async Task FindAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void FindAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Subscription.FindAsync(id);
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
        public void Update_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Subscription.Update(id, new SubscriptionRequest()));
            }
        }

        [Test]
#if netcore
        public async Task UpdateAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void UpdateAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Subscription.UpdateAsync(id, new SubscriptionRequest());
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
        public void Cancel_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Subscription.Cancel(id));
            }
        }

        [Test]
#if netcore
        public async Task CancelAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void CancelAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Subscription.CancelAsync(id);
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
