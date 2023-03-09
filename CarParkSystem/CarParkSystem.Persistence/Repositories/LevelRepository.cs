using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Repositories
{
    public class LevelRepository: ILevelRepository
    {
        private readonly CarParkDbContext _context;

        public LevelRepository(CarParkDbContext context)
        {
            _context = context;
        }
        
        public int AddLevel(Level l)
        {
            try
            {
                _context.Level.Add(l);
                _context.SaveChanges();
                return l.Id;
            }
            catch (Exception)
            {
                Console.WriteLine("AddLevel exception.");
                return -1;
            }
        }

        public void DeleteLevel(int id)
        {
            try
            {
                var l = _context.Level.FirstOrDefault(x => x.Id == id);
                _context.Level.Remove(l);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("DeleteLevel exception.");
            }
        }
        public void UpdateLevel(Level l)
        {
            try
            {
                var level = _context.Level.FirstOrDefault(x => x.Id == l.Id);
                level.IsActive = l.IsActive;
                level.LevelNumber = l.LevelNumber;
                level.Slot = l.Slot;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("UpdateLevel exception.");
            }
        }
        public List<Level> GetAllLevels()
        {
            return _context.Level.ToList();
        }
    }
}
