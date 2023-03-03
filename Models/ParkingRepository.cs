namespace Parking_App.Models
{
    public class ParkingRepository
    {
        private ParkingAppContext db;

        public ParkingRepository()
        {
            db = new ParkingAppContext();

        }

        public List<ParkingSpot> GetParkingSpotsByCity(string inputCity)
        {

            DateTime current = DateTime.Now;


            db.Parkings.Where(p => p.isBooked == true && DateTime.Compare(p.timer, current) <= 0).ToList().ForEach(p => p.isBooked = false);

            db.Parkings.Where(p => DateTime.Compare(p.timer, current) <= 0).ToList().ForEach(p => p.timer = current);

            db.SaveChanges();

            List<ParkingSpot> spots = db.Parkings.Where(p => (p.city == inputCity && p.isBooked == false)).ToList();
            return spots;
        }

        public ParkingSpot GetParkingSpot(int id)
        {
            ParkingSpot p = db.Parkings.Where(p => p.ID == id).FirstOrDefault();
            return p;
        }

        public void BookParkingSpot(int id)
        {
            DateTime expiryTime = DateTime.Now;
            expiryTime.AddMinutes(3);
            db.Parkings.Where(p => p.ID == id).ToList().ForEach(p => p.isBooked = true);
            db.Parkings.Where(p => p.ID == id).ToList().ForEach(p => p.timer = expiryTime);
            db.SaveChanges();
        }
    }
}
