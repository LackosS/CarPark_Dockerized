namespace CarParkSystem.Persistence.DTO
{
    public class SlotDTO
    {
        public int Id { get; set; }
        public int? LevelId { get; set; }
        public int SlotNumber { get; set; }
        public string Type { get; set; }
        public int InitialNumber { get; set; }
        public bool IsFree { get; set; }
    }
}
