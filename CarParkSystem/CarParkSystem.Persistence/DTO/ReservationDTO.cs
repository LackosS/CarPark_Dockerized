namespace CarParkSystem.Persistence.DTO
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int ParkingHouseId { get; set; }
        public int LevelId { get; set; }
        public int SlotId { get; set; }
        
        public string ParkingHouseName { get; set; }
        public int LevelNumber { get; set; }
        public int SlotNumber { get; set; }
        public String Date { get; set; }
    }
}
