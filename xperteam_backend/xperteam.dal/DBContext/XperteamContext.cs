using Microsoft.EntityFrameworkCore;
using xperteam.model;

namespace xperteam.dal.DBContext;

public partial class XperteamContext : DbContext
{
    public XperteamContext()
    {
    }

    public XperteamContext(DbContextOptions<XperteamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.IdGuide).HasName("pk_guide");

            entity.ToTable("guide");

            entity.Property(e => e.IdGuide).HasColumnName("id_guide");
            entity.Property(e => e.CountryOrigin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country_origin");
            entity.Property(e => e.DestinationCountry)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("destination_country");
            entity.Property(e => e.NumberGuide)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("number_guide");
            entity.Property(e => e.RecipientAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("recipient_address");
            entity.Property(e => e.RecipientEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recipient_email");
            entity.Property(e => e.RecipientName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("recipient_name");
            entity.Property(e => e.RecipientPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recipient_phone");
            entity.Property(e => e.SenderAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sender_address");
            entity.Property(e => e.SenderEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sender_email");
            entity.Property(e => e.SenderName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sender_name");
            entity.Property(e => e.SenderPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sender_phone");
            entity.Property(e => e.ShippingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("shipping_date");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            entity.HasMany(d => d.IdInvoices).WithMany(p => p.IdGuides)
                .UsingEntity<Dictionary<string, object>>(
                    "InvoiceGuide",
                    r => r.HasOne<Invoice>().WithMany()
                        .HasForeignKey("IdInvoice")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_invoice__invoice_g_invoice"),
                    l => l.HasOne<Guide>().WithMany()
                        .HasForeignKey("IdGuide")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_invoice__invoice_g_guide"),
                    j =>
                    {
                        j.HasKey("IdGuide", "IdInvoice").HasName("pk_invoice_guide");
                        j.ToTable("invoice_guide");
                        j.HasIndex(new[] { "IdInvoice" }, "invoice_guide2_fk");
                        j.HasIndex(new[] { "IdGuide" }, "invoice_guide_fk");
                    });
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.IdInvoice).HasName("pk_invoice");

            entity.ToTable("invoice");

            entity.Property(e => e.IdInvoice).HasColumnName("id_invoice");
            entity.Property(e => e.DateIssue)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_issue");
            entity.Property(e => e.EmissionPoint)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("emission_point");
            entity.Property(e => e.Establishment)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("establishment");
            entity.Property(e => e.Sequential).HasColumnName("sequential");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Tax)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tax");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            entity.HasMany(d => d.IdPayments).WithMany(p => p.IdInvoices)
                .UsingEntity<Dictionary<string, object>>(
                    "InvoicePayment",
                    r => r.HasOne<Payment>().WithMany()
                        .HasForeignKey("IdPayment")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_invoice__invoice_p_payment"),
                    l => l.HasOne<Invoice>().WithMany()
                        .HasForeignKey("IdInvoice")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_invoice__invoice_p_invoice"),
                    j =>
                    {
                        j.HasKey("IdInvoice", "IdPayment").HasName("pk_invoice_payment");
                        j.ToTable("invoice_payment");
                        j.HasIndex(new[] { "IdPayment" }, "invoice_payment2_fk");
                        j.HasIndex(new[] { "IdInvoice" }, "invoice_payment_fk");
                    });
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdPayment).HasName("pk_payment");

            entity.ToTable("payment");

            entity.Property(e => e.IdPayment).HasColumnName("id_payment");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("payment_type");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
