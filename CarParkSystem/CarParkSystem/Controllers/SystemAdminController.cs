using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
using CarParkSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarParkSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SystemAdminController : Controller
    {
        private ICompanyService _companyService;
        private IUserService _userService;
        private IParkingHouseService _parkingHouseService;
        private IReservationService _reservationService;

        public SystemAdminController(ICompanyService companyService, IUserService userService, IParkingHouseService parkingHouseService, IReservationService reservationService)
        {
            _companyService = companyService;
            _userService = userService;
            _parkingHouseService = parkingHouseService;
            _reservationService = reservationService;
        }

        [HttpPatch]
        [Route("UpdateCompanies")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin")]
        public IActionResult UpdateCompanies(CompanyDTO company)
        {
            _companyService.UpdateCompany(company);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCompany/{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin")]
        public ActionResult DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetCompanies")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin")]
        public ActionResult<List<CompanyDTO>> GetCompanies()
        {
            return Ok(_companyService.GetAllCompany());
        }
        [HttpGet]
        [Route("GetUsers")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin")]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
        [HttpGet]
        [Route("GetParkingHouses")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin")]
        public ActionResult<List<ParkingHouseDTO>> GetParkingHouses()
        {
            return Ok(_parkingHouseService.GetAllParkingHouses());
        }
        [HttpGet]
        [Route("GetReservations")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "SystemAdmin")]
        public ActionResult<List<ReservationDTO>> GetReservations()
        {
            return Ok(_reservationService.GetAllReservations());
        }
    }
}
