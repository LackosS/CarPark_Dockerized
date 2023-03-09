using CarParkSystem.Persistence.DTO;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Interfaces
{
    public interface ICustomMapper
    {
        public LevelDTO MapLevelToLevelDTO(Level l);
        public Level MapLevelDTOToLevel(LevelDTO ldto);
        public ReservationDTO MapReservationToReservationDTO(Reservation r);
        public Reservation MapReservationDTOToReservation(ReservationDTO rdto);
    }
}
