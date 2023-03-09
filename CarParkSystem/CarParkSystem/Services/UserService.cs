using AutoMapper;
using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void DeleteUser(string id)
        {
            _userRepository.DeleteUser(id);
        }
        public void UpdateUser(UserDTO u)
        {
            var user = _mapper.Map<User>(u);
            _userRepository.UpdateUser(user);
        }
        public List<UserDTO> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return _mapper.Map<List<UserDTO>>(users);
        }
        public List<UserDTO> GetAllUsers(int companyId)
        {
            var users = _userRepository.GetAllUsers().Where(x => x.CompanyId == companyId).ToList();
            return _mapper.Map<List<UserDTO>>(users);
        }
        public void ValidateUser(string id)
        {
            _userRepository.ValidateUser(id);
        }
        public void deValidateUser(string id)
        {
            _userRepository.deValidateUser(id);
        }
    }
}
