using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SenderId { get; set; }
        public required Client Sender { get; set; }
        public Guid RecipientId { get; set; }
        public required Client Recipient { get; set; }
        public decimal Value { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.PENDING;
        public string PixTxId { get; set; } = string.Empty;
        public string QrCodePayload { get; set; } = string.Empty;
        public DateTimeOffset ExpiresAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? ConfirmedAt { get; set; }
        public DateTimeOffset? ReversedAt { get; set; }
        public string? UrlProof { get; set; }
    }
}
