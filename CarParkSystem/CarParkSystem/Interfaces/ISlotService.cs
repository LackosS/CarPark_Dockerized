using CarParkSystem.Persistence.DTO;

namespace CarParkSystem.Interfaces
{
    public interface ISlotService
    {
        public int AddSlot(SlotDTO s);
        public void DeleteSlot(int id);
        public List<SlotDTO> GetAllSlots();
        public List<SlotDTO> GetAllSlots(int levelId);
        public void UpdateSlot(SlotDTO s);
        public bool IsSlotFree(int id, string date);
    }
}
