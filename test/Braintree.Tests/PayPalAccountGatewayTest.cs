using Braintree.Exceptions;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class PayPalAccountGatewayTest
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
        public void Find_InvalidTokenThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.PayPalAccount.Find("../customers/victim"));
        }

        [Test]
        public void Delete_InvalidTokenThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.PayPalAccount.Delete("../customers/victim"));
        }

        [Test]
        public void Update_InvalidTokenThrowsNotFoundException()
        {
            Assert.Throws<NotFoundException>(() => gateway.PayPalAccount.Update("../customers/victim", new PayPalAccountRequest()));
        }
    }
}
