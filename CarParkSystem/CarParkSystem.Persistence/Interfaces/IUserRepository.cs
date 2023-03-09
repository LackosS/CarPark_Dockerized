using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Interfaces
{
    public interface IUserRepository
    {
        public void DeleteUser(string id);
        public List<User> GetAllUsers();
        public void ValidateUser(string id);
        public void deValidateUser(string id);
        void UpdateUser(User usr);

    }
}
