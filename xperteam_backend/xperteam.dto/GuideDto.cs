
namespace xperteam.dto
{
    public class GuideDto
    {
        public int IdGuide { get; set; }

        public string? NumberGuide { get; set; }

        public DateTime? ShippingDate { get; set; }

        public string? CountryOrigin { get; set; }

        public string? SenderName { get; set; }

        public string? SenderAddress { get; set; }

        public string? SenderPhone { get; set; }

        public string? SenderEmail { get; set; }

        public string? DestinationCountry { get; set; }

        public string? RecipientName { get; set; }

        public string? RecipientAddress { get; set; }

        public string? RecipientPhone { get; set; }

        public string? RecipientEmail { get; set; }

        public decimal? Total { get; set; }
    }
}
