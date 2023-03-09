using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Interfaces
{
    public interface ISlotRepository
    {
        public int AddSlot(Slot s);
        public void DeleteSlot(int id);
        public List<Slot> GetAllSlots();
        public void UpdateSlot(Slot s);
        public bool IsSlotFree(int id, string date);
    }
}
