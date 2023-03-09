using System;
using System.Collections.Generic;

namespace xperteam.model;

public partial class Payment
{
    public int IdPayment { get; set; }

    public string? PaymentType { get; set; }

    public decimal? Value { get; set; }

    public virtual ICollection<Invoice> IdInvoices { get; } = new List<Invoice>();
}
