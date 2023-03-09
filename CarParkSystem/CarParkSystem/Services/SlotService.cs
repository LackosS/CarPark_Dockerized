using AutoMapper;
using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Services
{
    public class SlotService : ISlotService
    {
        private ISlotRepository _repository;
        private IMapper _mapper;

        public SlotService(ISlotRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int AddSlot(SlotDTO s)
        {
            var slot = _mapper.Map<Slot>(s);
            return _repository.AddSlot(slot);
        }
        public void DeleteSlot(int id)
        {
            _repository.DeleteSlot(id);
        }
        public void UpdateSlot(SlotDTO s)
        {
            var slot = _mapper.Map<Slot>(s);
            _repository.UpdateSlot(slot);
        }
        public bool IsSlotFree(int id, string date)
        {
            return _repository.IsSlotFree(id, date);
        }
        public List<SlotDTO> GetAllSlots()
        {
            var slots = _repository.GetAllSlots();
            return _mapper.Map<List<SlotDTO>>(slots);
        }
        public List<SlotDTO> GetAllSlots(int levelId)
        {
            var slots = _repository.GetAllSlots().Where(x => x.LevelId == levelId).ToList();
            return _mapper.Map<List<SlotDTO>>(slots);
        }
    }
}
