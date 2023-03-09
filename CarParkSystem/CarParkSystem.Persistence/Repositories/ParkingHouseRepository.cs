using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Repositories
{
    public class ParkingHouseRepository : IParkingHouseRepository
    {
        private readonly CarParkDbContext _context;

        public ParkingHouseRepository(CarParkDbContext context)
        {
            _context = context;
        }

        public int AddParkingHouse(ParkingHouse p)
        {
            try
            {
                _context.ParkingHouse.Add(p);
                _context.SaveChanges();
                return p.Id;
            }
            catch (Exception)
            {
                Console.WriteLine("AddParkingHouse exception.");
                return -1;
            }
        }

        public void DeleteParkingHouse(int id)
        {
            try
            {
                var p = _context.ParkingHouse.FirstOrDefault(x => x.Id == id);
                _context.ParkingHouse.Remove(p);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("DeleteParkingHouse exception.");
            }
        }

        public void UpdateParkingHouse(ParkingHouse p)
        {
            try
            {
                var parkingHouse = _context.ParkingHouse.FirstOrDefault(x => x.Id == p.Id);
                parkingHouse.Name = p.Name;
                parkingHouse.IsActive = p.IsActive;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("UpdateParkingHouse exception.");
            }
        }
        public List<ParkingHouse> GetAllParkingHouses()
        {
            return _context.ParkingHouse.ToList();
        }
    }
}
