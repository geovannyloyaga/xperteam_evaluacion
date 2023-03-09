

using System;

namespace xperteam.dto
{
    public class InvoiceDto
    {
        public int IdInvoice { get; set; }

        public string Establishment { get; set; } = null!;

        public string EmissionPoint { get; set; } = null!;

        public int? Sequential { get; set; }

        public DateTime? DateIssue { get; set; }

        public decimal? Subtotal { get; set; }

        public decimal? Tax { get; set; }

    }
}
