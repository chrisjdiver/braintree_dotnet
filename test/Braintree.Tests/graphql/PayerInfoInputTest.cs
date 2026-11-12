using Braintree;
using Braintree.GraphQL;
using NUnit.Framework;
using System.Collections.Generic;

namespace Braintree.Tests.GraphQL
{
    [TestFixture]
    public class PayerInfoInputTest
    {
        [Test]
        public void TestToGraphQLVariables()
        {
            var billingAddress = BillingAddressInput.Builder()
                .CountryCode("US")
                .StreetAddress("123 Main St")
                .Build();

            var shippingAddress = ShippingAddressInput.Builder()
                .CountryCode("US")
                .StreetAddress("456 Side St")
                .Build();

            var input = PayerInfoInput.Builder()
                .GivenName("Jane")
                .Surname("Doe")
                .Email("jane@example.com")
                .PhoneCountryCode("1")
                .PhoneNumber("3121234567")
                .BillingAddress(billingAddress)
                .ShippingAddress(shippingAddress)
                .Build();

            var dict = input.ToGraphQLVariables();

            Assert.AreEqual("Jane", dict["givenName"]);
            Assert.AreEqual("Doe", dict["surname"]);
            Assert.AreEqual("jane@example.com", dict["email"]);
            Assert.AreEqual("1", dict["phoneCountryCode"]);
            Assert.AreEqual("3121234567", dict["phoneNumber"]);

            CollectionAssert.AreEquivalent(
                billingAddress.ToGraphQLVariables(),
                (System.Collections.IEnumerable)dict["billingAddress"]
            );
            CollectionAssert.AreEquivalent(
                shippingAddress.ToGraphQLVariables(),
                (System.Collections.IEnumerable)dict["shippingAddress"]
            );
        }
    }
}
