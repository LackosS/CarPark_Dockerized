using CarParkSystem.Persistence.DTO;

namespace CarParkSystem.Interfaces
{
    public interface IUserService
    {
        public void DeleteUser(string id);
        public List<UserDTO> GetAllUsers();
        public List<UserDTO> GetAllUsers(int companyId);
        public void ValidateUser(string id);
        public void deValidateUser(string id);
        void UpdateUser(UserDTO u);
    }
}
