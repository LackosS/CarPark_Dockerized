using CarParkSystem.Interfaces;
using CarParkSystem.Persistence;
using CarParkSystem.Persistence.DTO;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.MappingConfigurations
{
    public class CustomMapper : ICustomMapper
    {
        private CarParkDbContext _context;

        public CustomMapper(CarParkDbContext context)
        {
            _context = context;
        }
        public LevelDTO MapLevelToLevelDTO(Level l)    
        {
            LevelDTO ldto = new LevelDTO();
            ldto.Id = l.Id;
            ldto.ParkingHouseId = l.ParkingHouseId;
            var pHouse = _context.ParkingHouse.FirstOrDefault(x => x.Id == l.ParkingHouseId);
            ldto.ParkingHouseName = pHouse.Name;
            ldto.IsActive = l.IsActive;
            ldto.LevelNumber = l.LevelNumber;
            ldto.Slot = l.Slot;
            return ldto;
        }
        public Level MapLevelDTOToLevel(LevelDTO ldto){
            Level l = new Level();
            l.Id = ldto.Id;
            l.ParkingHouseId = ldto.ParkingHouseId;
            l.IsActive = ldto.IsActive;
            l.LevelNumber = ldto.LevelNumber;
            l.Slot = ldto.Slot;
            return l;
        }

        public ReservationDTO MapReservationToReservationDTO(Reservation r)
        {
            ReservationDTO rdto = new ReservationDTO();
            rdto.Id = r.Id;
            rdto.ParkingHouseId = r.ParkingHouseId;
            rdto.ParkingHouseName = _context.ParkingHouse.FirstOrDefault(x => x.Id == r.ParkingHouseId).Name;
            rdto.UserId = r.UserId;
            rdto.LevelId = r.LevelId;
            rdto.LevelNumber = _context.Level.FirstOrDefault(x => x.Id == r.LevelId).LevelNumber;
            rdto.SlotId = r.SlotId;
            rdto.SlotNumber = _context.Slot.FirstOrDefault(x => x.Id == r.SlotId).SlotNumber;
            rdto.Date = r.Date;
            return rdto;
        }
        public Reservation MapReservationDTOToReservation(ReservationDTO rdto)
        {
            Reservation r = new Reservation();
            r.Id = rdto.Id;
            r.ParkingHouseId = rdto.ParkingHouseId;
            r.UserId = rdto.UserId;
            r.LevelId = rdto.LevelId;
            r.SlotId = rdto.SlotId;
            r.Date = rdto.Date;
            return r;
        }
    }
}
