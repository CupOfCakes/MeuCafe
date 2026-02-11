using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Payment.Create
{
    internal class PaymentCreateRequestDTO
    {
        public Guid RecipientId { get; set; }
        public decimal value { get; set; }
    }
}
