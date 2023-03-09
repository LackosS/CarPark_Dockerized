using CarParkSystem.Persistence.DTO;

namespace CarParkSystem.Interfaces
{
    public interface IReservationService
    {
        int AddReservation(ReservationDTO r);
        void DeleteReservation(int id);
        public bool IsUserHasReservation(string userId, string date);
        List<ReservationDTO> GetAllReservations();
        List<ReservationDTO> GetAllReservations(int parkingHouseId);
        List<ReservationDTO> GetAllReservations(string userId);
    }
}
