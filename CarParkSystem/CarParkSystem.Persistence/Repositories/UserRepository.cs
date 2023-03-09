using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarParkDbContext _context;

        public UserRepository(CarParkDbContext context)
        {
            _context = context;
        }
        public void DeleteUser(string id)
        {
            try
            {
                var u = _context.User.FirstOrDefault(x => x.Id == id);
                _context.User.Remove(u);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                Console.WriteLine("DeleteUser exception.");
            }
        }
        public void UpdateUser(User usr)
        {
            try
            {
                var u = _context.User.FirstOrDefault(x => x.Id == usr.Id);
                u.FullName = usr.FullName;
                u.UserName = usr.UserName;
                u.IsValid = usr.IsValid;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                Console.WriteLine("UpdateUser exception.");
            }
        }

        public void ValidateUser(string id)
        {
            try
            {
                var u = _context.User.FirstOrDefault(x => x.Id == id);
                u.IsValid = 1;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                Console.WriteLine("ValidateUser exception.");
            }
        }
        
        public void deValidateUser(string id)
        {
            try
            {
                var u = _context.User.FirstOrDefault(x => x.Id == id);
                u.IsValid = 0;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                Console.WriteLine("deValidateUser exception.");
            }
        }
        public List<User> GetAllUsers()
        {
            return _context.User.ToList();
        }
    }
}
