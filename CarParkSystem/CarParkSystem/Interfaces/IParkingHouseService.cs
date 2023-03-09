using CarParkSystem.Persistence.DTO;

namespace CarParkSystem.Interfaces
{
    public interface IParkingHouseService
    {
        int AddParkingHouse(ParkingHouseDTO p);
        void DeleteParkingHouse(int id);
        List<ParkingHouseDTO> GetAllParkingHouses();
        List<ParkingHouseDTO> GetAllParkingHouses(int companyId);
        void UpdateParkingHouse(ParkingHouseDTO p);
    }
}
