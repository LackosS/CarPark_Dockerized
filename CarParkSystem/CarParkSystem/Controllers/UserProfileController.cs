using CarParkSystem.Persistence.Models;
using CarParkSystem.Persistence.Records;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarParkSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]    
    public class UserProfileController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _singInManager;
        private RoleManager<IdentityRole> _roleManager;
        private Persistence.CarParkDbContext _context;
        private readonly ApplicationSettings _appSettings;
        private readonly IConfiguration _configuration;


        public UserProfileController(IConfiguration configuration,UserManager<User> userManager, SignInManager<User> signInManager, IOptions<ApplicationSettings> appSettings, RoleManager<IdentityRole> rolemanager, Persistence.CarParkDbContext context)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _roleManager = rolemanager;
            _appSettings = appSettings.Value;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("RegisterCompany")]
        public async Task<Object> CompanyRegister(CompanyRegisterModel m)
        {
            User u = new User();
            if (_context.Company.FirstOrDefault(x => x.Name == m.CompanyName) == null && m.CompanyName!="OWNER")
            {
                _context.Company.Add(new Company { Name = m.CompanyName, IsValid = 0, Users = { }, ParkingHouses = { } });
                _context.SaveChanges();
            }
            else
            {
                return BadRequest(new { message = "Company is already registered!" });
            }
            u.Role = "CompanyAdmin";
            u.FullName = m.Name;
            u.UserName = m.UserName;
            u.IsValid = 1;
            u.CompanyId = _context.Company.Where(x => x.Name == m.CompanyName).FirstOrDefault().Id;
            try
            {
                var result = await _userManager.CreateAsync(u, m.Password);
                if (result == null)
                {
                    throw new ArgumentNullException("Errors during the registration of the user!");
                }
                if (!await _roleManager.RoleExistsAsync("CompanyAdmin"))
                {
                    IdentityResult createResult = await _roleManager.CreateAsync(new IdentityRole("CompanyAdmin"));
                    if (!createResult.Succeeded) { throw new ArgumentException("Errors during the creation of the role!"); }
                }

                var user = await _userManager.FindByNameAsync(u.UserName);

                await _userManager.AddToRoleAsync(user, "CompanyAdmin");
                if(result.Errors.Count() != 0)
                {
                    Company c = _context.Company.FirstOrDefault<Company>(x => x.Id == u.CompanyId);
                    if (c != null)
                    {
                      _context.Company.Remove(c);
                      _context.SaveChanges();
                    } 
                }
                if(!result.Succeeded)
                {
                    return BadRequest(new { message = "Username '"+user.UserName+"' is already taken!"});
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Company c = _context.Company.FirstOrDefault<Company>(x => x.Id == u.CompanyId);
                if (c != null)
                {
                    _context.Company.Remove(c);
                    _context.SaveChanges();
                }
                return BadRequest(new { message = ex.Message });
            }

        }
        
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<Object> UserRegister(UserRegisterModel m)
        {
            User u = new User();

            u.FullName = m.FullName;
            u.UserName = m.UserName;
            u.CompanyId = m.CompanyId;
            u.Role = m.Post;
            u.IsValid = 0;
            
            try
            {
                var result = await _userManager.CreateAsync(u, m.Password);
                if (result == null)
                {
                    throw new ArgumentNullException("Errors during the registration of the user.");
                }

                if (!await _roleManager.RoleExistsAsync(u.Role))
                {
                    IdentityResult createResult = await _roleManager.CreateAsync(new IdentityRole(u.Role));
                    if (!createResult.Succeeded) { throw new ArgumentException("Errors during the creation of the role."); }
                }

                var user = await _userManager.FindByNameAsync(u.UserName);
                if(user != null) await _userManager.AddToRoleAsync(user, u.Role);
                if (!result.Succeeded)
                {
                    return BadRequest(new { message = "Username '" + user.UserName + "' is already taken." });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<Object> ChangePassword(ChangePasswordModel m)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(m.UserName);
                user.UserName = m.UserName;
                if (user == null)
                {
                    throw new ArgumentNullException("There is no user associated to this username.");
                }
                var result = await _userManager.ChangePasswordAsync(user, m.OldPassword, m.NewPassword);
                if (!result.Succeeded)
                {
                    return BadRequest(new { message= "Username or password is incorrect!" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel m)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(m.UserName);
                var company = _context.Company.First(x => x.Id == user.CompanyId);
                if (user != null && await _userManager.CheckPasswordAsync(user, m.Password))
                {
                    //var role = await _userManager.GetRolesAsync(user);
                    IdentityOptions _options = new IdentityOptions();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("userId", user.Id.ToString()),
                            new Claim("name", user.FullName),
                            //new Claim("username", user.UserName),
                            new Claim("isValid", user.IsValid.ToString()),
                            new Claim(_options.ClaimsIdentity.RoleClaimType, user.Role),
                            new Claim("companyId", user.CompanyId.ToString()),
                            new Claim("companyName", company.Name),
                            new Claim("companyIsValid", company.IsValid.ToString())
                        }),
                        Audience = _appSettings.Client_URL,
                        Issuer = _appSettings.Client_URL,
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
                else
                    throw new ArgumentException ("Username or password is incorrect!");
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Username or password is incorrect!" });
            }
        }

        [HttpPost]
        [Route("RegisterSystemAdmin")]
        public async Task<Object> SystemAdminRegister()
        {
            User u = new User();

            if (_context.Company.FirstOrDefault(x => x.Name == "OWNER") == null)
            {
                _context.Company.Add(new Company { Name = "OWNER", IsValid = 1, Users = { }, ParkingHouses = { } });
                _context.SaveChanges();
            }
            
            u.Role = "SystemAdmin";
            u.FullName = "Csonka László";
            u.UserName = _configuration["ApplicationSettings:SysAdminName"].ToString();
            u.CompanyId = _context.Company.Where(x => x.Name == "OWNER").FirstOrDefault().Id;            
            u.IsValid = 1;

            try
            {
                var result = await _userManager.CreateAsync(u, _configuration["ApplicationSettings:SysAdminPassword"].ToString());
                if (result == null)
                {
                    return false;
                }
                if (!await _roleManager.RoleExistsAsync("SystemAdmin"))
                {
                    IdentityResult createResult = await _roleManager.CreateAsync(new IdentityRole("SystemAdmin"));
                    if (!createResult.Succeeded) { return false; }
                }

                await _userManager.AddToRoleAsync(u, "SystemAdmin");
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Something wrong during the creation of sysadmin!");
            }

        }
    }
}
