using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Repositories
{
    public class SlotRepository : ISlotRepository
    {
        private readonly CarParkDbContext _context;
        public SlotRepository(CarParkDbContext context)
        {
            _context = context;
        }
        public int AddSlot(Slot s)
        {
            try
            {
                _context.Slot.Add(s);
                _context.SaveChanges();
                return s.Id;
            }
            catch (Exception)
            {
                Console.WriteLine("AddSlot exception.");
                return -1;
            }
        }
        public void UpdateSlot(Slot s)
        {
            try
            {
                var slot = _context.Slot.FirstOrDefault(x => x.Id == s.Id);
                slot.SlotNumber = s.SlotNumber;
                slot.Type = s.Type;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("UpdateSlot exception.");
            }
        }
        public void DeleteSlot(int id)
        {
            try
            {
                var s = _context.Slot.FirstOrDefault(x => x.Id == id);
                _context.Slot.Remove(s);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("DeleteSlot exception.");
            }
        }
        public bool IsSlotFree(int id, string date)
        {
            try
            {
                var reservation = _context.Reservation.FirstOrDefault(x => x.SlotId == id && x.Date == date);
                if (reservation == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("IsSlotFree exception.");
                return false;
            }
        }
        public List<Slot> GetAllSlots()
        {
            return _context.Slot.ToList();
        }
    }
}
