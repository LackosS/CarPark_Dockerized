using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Interfaces
{
    public interface IParkingHouseRepository
    {
        public int AddParkingHouse(ParkingHouse p);
        public void DeleteParkingHouse(int id);
        void UpdateParkingHouse(ParkingHouse p);
        public List<ParkingHouse> GetAllParkingHouses();
    }
}
