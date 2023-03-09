using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarParkSystem.Persistence.Records
{
    public class User : IdentityUser
    {
        public int? CompanyId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public int IsValid { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
