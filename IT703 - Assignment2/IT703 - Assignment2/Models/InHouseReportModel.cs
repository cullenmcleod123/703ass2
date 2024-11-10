namespace IT703___Assignment2.Models
{
    public class InHouseReportModel
    {
        public int BookingID { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string BookingStatus { get; set; }
    }

}
