using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
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
        //[Authorize(Roles="SystemAdmin,asd")] //több roles
        public IActionResult AddReservation(ReservationDTO r)
        {
            return Ok(_reservationService.AddReservation(r));
        }
        [HttpDelete]
        [Route("DeleteReservation/{id}")]
        //[Authorize(Roles="SystemAdmin")]
        public IActionResult DeleteReservation(int id)
        {
            _reservationService.DeleteReservation(id);
            return Ok();
        }
        //[HttpGet("{userId}")] //ezzel próbáljam és akkor /userId
        [HttpGet]
        [Route("GetReservations/{userId}")]
        //[Authorize(Roles="SystemAdmin")]
        public IActionResult GetReservations(string userId)
        {
            return Ok(_reservationService.GetAllReservations(userId));
        }
        [HttpGet]
        [Route("IsUserHasReservation/{userId}/{date}")]
        public IActionResult IsUserHasReservation(string userId, string date)
        {
            return Ok(_reservationService.IsUserHasReservation(userId, date));
        }
        [HttpGet]
        [Route("IsSlotFree/{id}/{date}")]
        public IActionResult IsSlotFree(int id, string date)
        {
            return Ok(_slotService.IsSlotFree(id, date));
        }
    }
}
