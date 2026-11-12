using Braintree.Exceptions;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class AddressGatewayTest
    {
        private BraintreeGateway gateway;
        private IAddressGateway addressGateway;

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

            addressGateway = gateway.Address;
        }

        [Test]
        public void Create_InvalidCustomerIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => addressGateway.Create("../../foo", new AddressRequest()));
        }

        [Test]
        public void Find_InvalidCustomerIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => addressGateway.Find("../../foo", "id"));
        }

        [Test]
        public void Find_InvalidAddressIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => addressGateway.Find("customerId", "../../foo"));
        }

        [Test]
        public void Update_InvalidAddressIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => addressGateway.Update("customerId", "a/b", new AddressRequest()));
        }

        [Test]
        public void Delete_InvalidAddressIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => addressGateway.Delete("customerId", ".."));
        }

        [Test]
        public void Find_DotAddressIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => addressGateway.Find("customerId", "."));
        }

        [Test]
        public void Find_DottedAddressIdThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => addressGateway.Find("customerId", "foo.bar"));
        }
    }
}
