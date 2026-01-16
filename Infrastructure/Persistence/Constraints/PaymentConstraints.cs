using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Constraints
{
    public static class PaymentConstraints
    {
        public const string FKRecipient = "fk_recipient";
        public const string FKSender = "fk_sender";
        public const string CheckPaymentStatus = "chk_payment_status";
    }
}
