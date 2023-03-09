using AutoMapper;
using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Services
{
    public class LevelService : ILevelService
    {
        private ILevelRepository _repository;
        private ICustomMapper _customMapper;
        public LevelService(ILevelRepository repository,ICustomMapper customMapper)
        {
            _repository = repository;
            _customMapper = customMapper;
        }
        public int AddLevel(LevelDTO l)
        {
            var level = _customMapper.MapLevelDTOToLevel(l);
            return _repository.AddLevel(level);
        }
        public void UpdateLevel(LevelDTO l)
        {
            var level = _customMapper.MapLevelDTOToLevel(l);
            _repository.UpdateLevel(level);
        }
        public void DeleteLevel(int id)
        {
            _repository.DeleteLevel(id);
        }
        public List<LevelDTO> GetAllLevels()
        {
            List<LevelDTO> levelDTOs = new List<LevelDTO>();
            var levels = _repository.GetAllLevels();
            foreach (var level in levels)
            {
                var lvl = _customMapper.MapLevelToLevelDTO(level);
                levelDTOs.Add(lvl);
            }
            return levelDTOs;
        }
        public List<LevelDTO> GetAllLevels(int parkingHouseId)
        {
            List<LevelDTO> levelDTOs = new List<LevelDTO>();
            var levels = _repository.GetAllLevels().Where(x => x.ParkingHouseId == parkingHouseId).ToList();
            foreach (var level in levels)
            {
                var lvl = _customMapper.MapLevelToLevelDTO(level);
                levelDTOs.Add(lvl);
            }
            return levelDTOs;
        }
    }
}
