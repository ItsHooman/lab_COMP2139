namespace GBC_TRAVEL.Models
{
    public class Hotel
    {

        public int HotelID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal PricePerNight { get; set; }
        // Assuming ratings are from 1 to 5
        public int Rating { get; set; }
    }
}
