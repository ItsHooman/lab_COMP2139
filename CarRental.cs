namespace GBC_TRAVEL.Models
{
    public class CarRental
    {
        public int CarRentalID { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string CarType { get; set; }
        public decimal PricePerDay { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropoffDate { get; set; }
       
    }
}
