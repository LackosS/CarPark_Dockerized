using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Interfaces
{
    public interface ILevelRepository
    {
        public int AddLevel(Level l);
        public void DeleteLevel(int id);
        public List<Level> GetAllLevels();
        void UpdateLevel(Level l);
    }
}
