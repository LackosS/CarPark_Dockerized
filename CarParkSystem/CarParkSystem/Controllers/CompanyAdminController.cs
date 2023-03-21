using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarParkSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyAdminController : Controller
    {
        private IParkingHouseService _parkingHouseService;
        private IUserService _userService;
        private ILevelService _levelService;
        private ISlotService _slotService;
        private IReservationService _reservationService;
        public CompanyAdminController(IParkingHouseService parkingHouseService, IUserService userService, ILevelService levelService, ISlotService slotService,IReservationService reservationService )
        {
            _parkingHouseService = parkingHouseService;
            _userService = userService;
            _levelService = levelService;
            _slotService = slotService;
            _reservationService = reservationService;
        }
        
        [HttpPost]
        [Route("AddParkingHouse")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult AddParkingHouse(ParkingHouseDTO p)
        {
            return Ok(_parkingHouseService.AddParkingHouse(p));
        }
        [HttpPost]
        [Route("AddLevel")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult AddLevel(LevelDTO l)
        {
             return Ok(_levelService.AddLevel(l));
        }
        [HttpPost]
        [Route("AddSlot")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult AddSlot(SlotDTO s)
        {
             return Ok(_slotService.AddSlot(s));
        }
        [HttpPost]
        [Route("AddSlots")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult AddSlots(SlotDTO s)
        {
            for (int i = 0; i < s.InitialNumber; i++)
            {
                s.SlotNumber = i + 1;
                _slotService.AddSlot(s);
            }
            return Ok();
        }
        [HttpPatch]
        [Route("UpdateUsers")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult UpdateUsers(UserDTO user)
        {
            _userService.UpdateUser(user);
            return Ok();
        }
        [HttpPatch]
        [Route("UpdateParkingHouses")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult UpdateParkingHouses(ParkingHouseDTO parkingHouse)
        {
            _parkingHouseService.UpdateParkingHouse(parkingHouse);
            return Ok();
        }
        [HttpPatch]
        [Route("UpdateLevels")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult UpdateLevels(LevelDTO level)
        {
            _levelService.UpdateLevel(level);
            return Ok();
        }
        [HttpPatch]
        [Route("UpdateSlots")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]        
        public IActionResult UpdateSlots(List<SlotDTO> slots)
        {
            foreach (var slot in slots)
            {
                _slotService.UpdateSlot(slot);
            }
            return Ok();
        }
        [HttpGet]
        [Route("GetUsers/{companyId}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult GetUsers(int companyId)
        {
            return Ok(_userService.GetAllUsers(companyId));
        }
        [HttpGet]
        [Route("GetReservations/{userId}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult GetReservations(string userId)
        {
            return Ok(_reservationService.GetAllReservations(userId));
        }
        [HttpGet]
        [Route("GetParkingHouses/{companyId}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin,Boss,Employee")]
        public IActionResult GetParkingHouses(int companyId)
        {
            return Ok(_parkingHouseService.GetAllParkingHouses(companyId));
        }
        [HttpGet]
        [Route("GetLevels/{parkingHouseId}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin,Boss,Employee")]
        public IActionResult GetLevels(int parkingHouseId)
        {
            return Ok(_levelService.GetAllLevels(parkingHouseId));
        }
        [HttpGet]
        [Route("GetSlots/{levelId}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin,Boss,Employee")]
        public IActionResult GetSlots(int levelId)
        {
            return Ok(_slotService.GetAllSlots(levelId));
        }

        [HttpDelete]
        [Route("DeleteLevel/{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult DeleteLevel(int id)
        {
            _levelService.DeleteLevel(id);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteParkingHouse/{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult DeleteParkingHouse(int id)
        {
            _parkingHouseService.DeleteParkingHouse(id);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteSlots")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult DeleteSlots(List<SlotDTO>slots)
        {
            foreach (var slot in slots)
            {
                _slotService.DeleteSlot(slot.Id);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "CompanyAdmin")]
        public IActionResult DeleteUser(string id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }

    }
}
