using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarParkSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DefaultUserController : Controller
    {
        private IParkingHouseService _parkingHouseService;
        private IUserService _userService;
        private IReservationService _reservationService;
        private ICompanyService _companyService;
        private ISlotService _slotService;
        public DefaultUserController(IParkingHouseService parkingHouseService, IUserService userService,IReservationService reservationService, ICompanyService companyService, ISlotService slotService)
        {
            _parkingHouseService = parkingHouseService;
            _userService = userService;
            _reservationService = reservationService;
            _companyService = companyService;
            _slotService = slotService;
        }

        [HttpPost]
        [Route("AddReservation")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin,CompanyAdmin,Boss,Employee")]
        public IActionResult AddReservation(ReservationDTO r)
        {
            return Ok(_reservationService.AddReservation(r));
        }
        [HttpDelete]
        [Route("DeleteReservation/{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin,CompanyAdmin,Boss,Employee")]
        public IActionResult DeleteReservation(int id)
        {
            _reservationService.DeleteReservation(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetReservations/{userId}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin,CompanyAdmin,Boss,Employee")]
        public IActionResult GetReservations(string userId)
        {
            return Ok(_reservationService.GetAllReservations(userId));
        }
        [HttpGet]
        [Route("IsUserHasReservation/{userId}/{date}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin,CompanyAdmin,Boss,Employee")]
        public IActionResult IsUserHasReservation(string userId, string date)
        {
            return Ok(_reservationService.IsUserHasReservation(userId, date));
        }
        [HttpGet]
        [Route("IsSlotFree/{id}/{date}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin,CompanyAdmin,Boss,Employee")]
        public IActionResult IsSlotFree(int id, string date)
        {
            return Ok(_slotService.IsSlotFree(id, date));
        }
    }
}
