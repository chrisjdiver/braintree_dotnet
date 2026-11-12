using Braintree;
using Braintree.GraphQL;
using NUnit.Framework;
using System.Collections.Generic;

namespace Braintree.Tests.GraphQL
{
    [TestFixture]
    public class CreateLocalPaymentContextInputTest
    {
        [Test]
        public void TestToGraphQLVariables()
        {
            var payerInfo = PayerInfoInput.Builder()
                .GivenName("Jane")
                .Surname("Doe")
                .Build();

            var input = CreateLocalPaymentContextInput.Builder()
                .Amount(10.00M, "EUR")
                .Type("ideal")
                .PayerInfo(payerInfo)
                .ReturnUrl("https://example.com/return")
                .CancelUrl("https://example.com/cancel")
                .MerchantAccountId("merchant_account_id")
                .OrderId("order-1")
                .CountryCode("NL")
                .ExpiryDate("2026-01-01")
                .PaymentId("payment-1")
                .Build();

            var dict = input.ToGraphQLVariables();
            var paymentContext = (Dictionary<string, object>)dict["paymentContext"];

            Assert.AreEqual("ideal", paymentContext["type"]);
            Assert.AreEqual("https://example.com/return", paymentContext["returnUrl"]);
            Assert.AreEqual("https://example.com/cancel", paymentContext["cancelUrl"]);
            Assert.AreEqual("merchant_account_id", paymentContext["merchantAccountId"]);
            Assert.AreEqual("order-1", paymentContext["orderId"]);
            Assert.AreEqual("NL", paymentContext["countryCode"]);
            Assert.AreEqual("2026-01-01", paymentContext["expiryDate"]);
            Assert.AreEqual("payment-1", paymentContext["paymentId"]);

            CollectionAssert.AreEquivalent(
                payerInfo.ToGraphQLVariables(),
                (System.Collections.IEnumerable)paymentContext["payerInfo"]
            );
            var amount = (Dictionary<string, object>)paymentContext["amount"];
            Assert.AreEqual("10.00", amount["value"].ToString());
            Assert.AreEqual("EUR", amount["currencyCode"]);
        }
    }
}
