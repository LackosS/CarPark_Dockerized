using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarParkDbContext _context;
        public ReservationRepository(CarParkDbContext context)
        {
            _context = context;
        }
        public int AddReservation(Reservation r)
        {
            try
            {
                _context.Reservation.Add(r);
                _context.SaveChanges();
                return r.Id;
            }
            catch (Exception)
            {
                Console.WriteLine("AddReservation exception.");
                return -1;
            }
        }

        public void DeleteReservation(int id)
        {
            try
            {
                var r = _context.Reservation.FirstOrDefault(x => x.Id == id);
                _context.Reservation.Remove(r);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("DeleteReservation exception.");
            }
        }
        public bool IsUserHasReservation(string userId, string date)
        {
            try
            {
                var reservation = _context.Reservation.FirstOrDefault(x => x.UserId == userId && x.Date == date);
                if (reservation != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("IsUserHasReservation exception.");
                return false;
            }
        }
        public List<Reservation> GetAllReservations()
        {
            return _context.Reservation.ToList();
        }
    }
}
