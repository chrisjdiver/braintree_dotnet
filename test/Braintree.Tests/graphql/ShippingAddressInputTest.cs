using Braintree;
using Braintree.GraphQL;
using NUnit.Framework;
using System.Collections.Generic;

namespace Braintree.Tests.GraphQL
{
    [TestFixture]
    public class ShippingAddressInputTest
    {
        [Test]
        public void TestToGraphQLVariables()
        {
            var input = ShippingAddressInput.Builder()
                .CountryCode("US")
                .StreetAddress("123 Main St")
                .ExtendedAddress("Apt 4")
                .Locality("Chicago")
                .Region("IL")
                .PostalCode("60601")
                .Build();

            var dict = input.ToGraphQLVariables();

            Assert.AreEqual("US", dict["countryCode"]);
            Assert.AreEqual("123 Main St", dict["streetAddress"]);
            Assert.AreEqual("Apt 4", dict["extendedAddress"]);
            Assert.AreEqual("Chicago", dict["locality"]);
            Assert.AreEqual("IL", dict["region"]);
            Assert.AreEqual("60601", dict["postalCode"]);
        }
    }
}
