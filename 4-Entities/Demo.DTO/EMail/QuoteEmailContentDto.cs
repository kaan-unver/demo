namespace Demo.DTO.EMail
{
    public class QuoteEmailContentDto:EmailContentDto
    {
        public Guid ReqQuoteId { get; set; }
        public int ReqQuoteNo { get; set; }
        public DateTime DocDueDate { get; set; }
        public bool IsDomestic { get; set; }
    }
}
