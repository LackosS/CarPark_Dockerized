using AutoMapper;
using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Services
{
    public class ParkingHouseService : IParkingHouseService
    {
        private IParkingHouseRepository _repository;
        private IMapper _mapper;
        
        public ParkingHouseService(IParkingHouseRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int AddParkingHouse(ParkingHouseDTO p)
        {
            var parkinghouse = _mapper.Map<ParkingHouse>(p);
            return _repository.AddParkingHouse(parkinghouse);
        }

        public void DeleteParkingHouse(int id)
        {
            _repository.DeleteParkingHouse(id);
        }
        public void UpdateParkingHouse(ParkingHouseDTO p)
        {
            var parkinghouse = _mapper.Map<ParkingHouse>(p);
            _repository.UpdateParkingHouse(parkinghouse);
        }

        public List<ParkingHouseDTO> GetAllParkingHouses()
        {
            var parkingHouses = _repository.GetAllParkingHouses();
            return _mapper.Map<List<ParkingHouseDTO>>(parkingHouses);
        }
        public List<ParkingHouseDTO> GetAllParkingHouses(int companyId)
        {
            var parkingHouses = _repository.GetAllParkingHouses().Where(x => x.CompanyId == companyId).ToList();
            return _mapper.Map<List<ParkingHouseDTO>>(parkingHouses);
        }
    }
}
