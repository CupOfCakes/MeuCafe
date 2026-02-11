using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Payment.Create
{
    internal class PaymentResponseDTO
    {
        public int PaymentId { get; set; }
        public string QrCodePayload { get; set; } = string.Empty;
        public DateTimeOffset ExpiresAt { get; set; } = DateTimeOffset.UtcNow;
        public PaymentStatus Status { get; set; } = PaymentStatus.PENDING;
    }
}
