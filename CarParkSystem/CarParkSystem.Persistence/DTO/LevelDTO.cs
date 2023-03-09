using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.DTO
{
    public class LevelDTO
    {
        public int Id { get; set; }
        public int? ParkingHouseId { get; set; }
        public string ParkingHouseName { get; set; }
        public int IsActive { get; set; }
        public int LevelNumber { get; set; }
        public int Slot { get; set; }
    }
}
