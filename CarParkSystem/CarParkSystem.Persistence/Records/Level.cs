using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarParkSystem.Persistence.Records
{
    public class Level
    {
        [Key]
        public int Id { get; set; }
        public int? ParkingHouseId { get; set; }
        public int IsActive { get; set; }
        public int LevelNumber { get; set; }
        public int Slot { get; set; }

        public ParkingHouse ParkingHouse { get; set; }
        public ICollection<Slot> Slots { get; set; }
    }
}
