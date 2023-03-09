using CarParkSystem.Persistence.DTO;

namespace CarParkSystem.Interfaces
{
    public interface ILevelService
    {
        int AddLevel(LevelDTO l);
        void DeleteLevel(int id);
        List<LevelDTO> GetAllLevels();
        List<LevelDTO> GetAllLevels(int parkingHouseId);
        void UpdateLevel(LevelDTO l);
    }
}
