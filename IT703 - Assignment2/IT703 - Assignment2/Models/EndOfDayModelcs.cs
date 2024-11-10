namespace IT703___Assignment2.Models
{
    public class EndOfDayModel
    {
        public int BookingID { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateBooked { get; set; }
        public DateTime LeavingDate { get; set; }
        public string BookingStatus { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string? PaymentType { get; set; }
        public DateTime? PaymentDate { get; set; }
    }

    public class PaymentSummary
    {
        public decimal? TotalAmount { get; set; }
        public int? TotalTransactions { get; set; }
    }

}
