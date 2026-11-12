using Braintree.Exceptions;
using NUnit.Framework;
using System;
using System.Xml;

namespace Braintree.Tests
{
    [TestFixture]
    public class TransactionSearchRequestTest
    {
        private BraintreeGateway gateway;
        private BraintreeService service;

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

            service = new BraintreeService(gateway.Configuration);
        }
        [Test]
        public void Search_ByDebitNetwork(){
          string[] allowedNetworks = {
                Braintree.TransactionDebitNetwork.NYCE.GetDescription(),
                Braintree.TransactionDebitNetwork.ACCEL.GetDescription(),
                Braintree.TransactionDebitNetwork.MAESTRO.GetDescription(),
                Braintree.TransactionDebitNetwork.NYCE.GetDescription(),
                Braintree.TransactionDebitNetwork.PULSE.GetDescription(),
                Braintree.TransactionDebitNetwork.STAR.GetDescription(),
                Braintree.TransactionDebitNetwork.STAR_ACCESS.GetDescription()
            };
          TransactionSearchRequest searchRequest = new TransactionSearchRequest().
                Id.Is("1234").
                DebitNetwork.IncludedIn(allowedNetworks);
          
          Assert.AreEqual(searchRequest.ToXml(),"<search><id><is>1234</is></id><debit-network type=\"array\"><item>NYCE</item><item>ACCEL</item><item>MAESTRO</item><item>NYCE</item><item>PULSE</item><item>STAR</item><item>STAR_ACCESS</item></debit-network></search>");
        }

        [Test]
        public void Search_ByAchType()
        {
            string sameDayXml = new TransactionSearchRequest().
                AchType.IncludedIn(TransactionAchType.SAME_DAY).
                ToXml();
            StringAssert.Contains("<ach-type type=\"array\"><item>same_day</item></ach-type>", sameDayXml);

            string standardXml = new TransactionSearchRequest().
                AchType.IncludedIn(TransactionAchType.STANDARD).
                ToXml();
            StringAssert.Contains("<ach-type type=\"array\"><item>standard</item></ach-type>", standardXml);

            string bothXml = new TransactionSearchRequest().
                AchType.IncludedIn(TransactionAchType.SAME_DAY, TransactionAchType.STANDARD).
                ToXml();
            StringAssert.Contains("<ach-type type=\"array\"><item>same_day</item><item>standard</item></ach-type>", bothXml);
        }
    }
}
