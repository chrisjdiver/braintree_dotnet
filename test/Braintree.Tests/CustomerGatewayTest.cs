using Braintree.Exceptions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Braintree.Tests
{
    [TestFixture]
    public class CustomerGatewayTest
    {
        private BraintreeGateway gateway;

        private static readonly string[] InvalidIds = { null, "", ".", "../transactions/some_id/void" };
        private static readonly string[] InvalidTokens = { null, "", ".", "../payment_methods/any/some_token" };

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
                Assert.Throws<NotFoundException>(() => gateway.Customer.Find(id));
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
                    await gateway.Customer.FindAsync(id);
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
        public void FindWithAssociationFilterId_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Customer.Find(id, "filter_id"));
            }
        }

        [Test]
        public void FindWithAssociationFilterId_InvalidAssociationFilterIdThrowsNotFoundException()
        {
            foreach (var filterId in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Customer.Find("customer_id", filterId));
            }
        }

        [Test]
        public void Delete_InvalidIdThrowsNotFoundException()
        {
            foreach (var token in InvalidTokens)
            {
                Assert.Throws<NotFoundException>(() => gateway.Customer.Delete(token));
            }
        }

        [Test]
#if netcore
        public async Task DeleteAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void DeleteAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var token in InvalidTokens)
            {
                try
                {
                    await gateway.Customer.DeleteAsync(token);
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
                Assert.Throws<NotFoundException>(() => gateway.Customer.Update(id, new CustomerRequest()));
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
                    await gateway.Customer.UpdateAsync(id, new CustomerRequest());
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
