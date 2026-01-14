using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; } = string.Empty;
        public string PixTxId { get; set; } = string.Empty;
        public string QrCodePayload { get; set; } = string.Empty;
        public DateTimeOffset ExpiresAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ConfirmedAt { get; set; }
        public DateTimeOffset? ReversedAt { get; set; }
        public string? UrlProof { get; set; }
    }
}
