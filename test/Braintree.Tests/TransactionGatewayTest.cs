using Braintree.Exceptions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionGatewayTest
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
        public void AdjustAuthorization_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.AdjustAuthorization(id, 1.00m));
            }
        }

        [Test]
#if netcore
        public async Task AdjustAuthorizationAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void AdjustAuthorizationAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Transaction.AdjustAuthorizationAsync(id, 1.00m);
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
        public void CancelRelease_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.CancelRelease(id));
            }
        }

        [Test]
#if netcore
        public async Task CancelReleaseAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void CancelReleaseAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Transaction.CancelReleaseAsync(id);
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
        public void Find_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.Find(id));
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
                    await gateway.Transaction.FindAsync(id);
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
        public void Refund_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.Refund(id));
            }
        }

        [Test]
#if netcore
        public async Task RefundAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void RefundAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Transaction.RefundAsync(id);
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
        public void RefundWithAmount_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.Refund(id, 1.00m));
            }
        }

        [Test]
        public void Reverse_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.Reverse(id));
            }
        }

        [Test]
#if netcore
        public async Task ReverseAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void ReverseAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Transaction.ReverseAsync(id);
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
#if netcore
        public async Task RefundWithAmountAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void RefundWithAmountAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Transaction.RefundAsync(id, 1.00m);
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
        public void SubmitForSettlement_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.SubmitForSettlement(id));
            }
        }

        [Test]
#if netcore
        public async Task SubmitForSettlementAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void SubmitForSettlementAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Transaction.SubmitForSettlementAsync(id);
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
        public void UpdateDetails_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.UpdateDetails(id, new TransactionRequest()));
            }
        }

        [Test]
        public void PackageTracking_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.PackageTracking(id, new PackageTrackingRequest()));
            }
        }

        [Test]
#if netcore
        public async Task PackageTrackingAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void PackageTrackingAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Transaction.PackageTrackingAsync(id, new PackageTrackingRequest());
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
        public void SubmitForPartialSettlement_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.SubmitForPartialSettlement(id, 1.00m));
            }
        }

        [Test]
        public void Void_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.Void(id));
            }
        }

        [Test]
#if netcore
        public async Task VoidAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void VoidAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Transaction.VoidAsync(id);
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
        public void CloneTransaction_InvalidIdThrowsNotFoundException()
        {
            foreach (var id in InvalidIds)
            {
                Assert.Throws<NotFoundException>(() => gateway.Transaction.CloneTransaction(id, new TransactionCloneRequest()));
            }
        }

        [Test]
#if netcore
        public async Task CloneTransactionAsync_InvalidIdThrowsNotFoundExceptionAsync()
#else
        public void CloneTransactionAsync_InvalidIdThrowsNotFoundExceptionAsync()
        {
            Task.Run(async () =>
#endif
        {
            foreach (var id in InvalidIds)
            {
                try
                {
                    await gateway.Transaction.CloneTransactionAsync(id, new TransactionCloneRequest());
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
