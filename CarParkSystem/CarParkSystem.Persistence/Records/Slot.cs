using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarParkSystem.Persistence.Records
{
    public class Slot
    {
        [Key]
        public int Id { get; set; }
        public int? LevelId { get; set; }
        public int SlotNumber { get; set; }
        public string Type { get; set; }
        public Level Level { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }

    }
}
