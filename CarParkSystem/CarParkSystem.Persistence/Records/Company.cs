using System.ComponentModel.DataAnnotations;

namespace CarParkSystem.Persistence.Records
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsValid { get; set; } //1 - Valid ----- 0 - InValid

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<ParkingHouse> ParkingHouses { get; set; }
    }
}
