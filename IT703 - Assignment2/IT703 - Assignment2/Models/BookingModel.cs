using System.ComponentModel.DataAnnotations;

namespace IT703___Assignment2.Models
{
    public class BookingModel
    {
        public int BookingID { get; set; }
        [DataType(DataType.Date)] 
        public DateTime DateBooked { get; set; }
        [DataType(DataType.Date)]
        public DateTime LeavingDate { get; set; }

        public int RoomID { get; set; }

        public int CustomerID { get; set; }

        public int CarParkID { get; set; }
        public string BookingStatus { get; set;}

    }
}
