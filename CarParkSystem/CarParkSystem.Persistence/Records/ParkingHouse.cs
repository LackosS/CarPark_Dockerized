using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarParkSystem.Persistence.Records
{
    public class ParkingHouse
    {
        [Key]
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public String Name { get; set; }
        public int IsActive { get; set; }
        public int Level { get; set; }
        public int Slots { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Level> Levels { get; set; }
    }
}
