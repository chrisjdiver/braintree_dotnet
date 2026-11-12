using Braintree.Exceptions;
using System.Xml;

namespace Braintree
{
    public class SepaDirectDebitAccountGateway : ISepaDirectDebitAccountGateway
    {
        private readonly BraintreeService service;
        private readonly BraintreeGateway gateway;

        public SepaDirectDebitAccountGateway(BraintreeGateway gateway)
        {
            gateway.Configuration.AssertHasAccessTokenOrKeys();
            this.gateway = gateway;
            service = gateway.Service;
        }

        public SepaDirectDebitAccount Find(string token)
        {
            if(StringUtil.IsInvalidPathSegment(token))
                throw new NotFoundException();

            XmlNode xml = service.Get(service.MerchantPath() + "/payment_methods/sepa_debit_account/" + token);

            return new SepaDirectDebitAccount(new NodeWrapper(xml), gateway);
        }

        public void Delete(string token)
        {
            if(StringUtil.IsInvalidPathSegment(token))
                throw new NotFoundException();

            service.Delete(service.MerchantPath() + "/payment_methods/sepa_debit_account/" + token);
        }
    }
}

