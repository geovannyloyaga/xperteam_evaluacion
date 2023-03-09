using System;
using System.Collections.Generic;

namespace xperteam.model;

public partial class Invoice
{
    public int IdInvoice { get; set; }

    public string Establishment { get; set; } = null!;

    public string EmissionPoint { get; set; } = null!;

    public int? Sequential { get; set; }

    public DateTime? DateIssue { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<Guide> IdGuides { get; } = new List<Guide>();

    public virtual ICollection<Payment> IdPayments { get; } = new List<Payment>();
}
