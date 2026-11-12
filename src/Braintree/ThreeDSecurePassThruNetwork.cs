using System.ComponentModel;

namespace Braintree
{
    public enum ThreeDSecurePassThruNetwork
    {
        [Description("eftpos")] EFTPOS,
        [Description("Mastercard")] MASTER_CARD,
        [Description("Visa")] VISA
    }
}
