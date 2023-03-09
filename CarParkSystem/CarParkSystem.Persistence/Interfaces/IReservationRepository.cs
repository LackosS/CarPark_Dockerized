using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Interfaces
{
    public interface IReservationRepository
    {
        public int AddReservation(Reservation r);
        public void DeleteReservation(int id);
        public bool IsUserHasReservation(string userId, string date);
        public List<Reservation> GetAllReservations();
    }
}
