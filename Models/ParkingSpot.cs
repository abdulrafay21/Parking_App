namespace Parking_App.Models
{
    public class ParkingSpot
    {
        public long ID { get; set; }
        public string? name { get; set; }
        public string? city { get; set; }

        public bool isBooked { get; set; }
        public int price { get; set; }
        public DateTime timer { get; set; }

    }
}
