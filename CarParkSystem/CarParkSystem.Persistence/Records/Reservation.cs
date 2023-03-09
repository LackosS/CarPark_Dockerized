using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarParkSystem.Persistence.Records
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int ParkingHouseId { get; set; }
        public int LevelId { get; set; }
        public int SlotId { get; set; }
        public String Date { get; set; }

        public User User { get; set; }
    }
}
