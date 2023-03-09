namespace CarParkSystem.Persistence.DTO
{
    public class ParkingHouseDTO
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public String Name { get; set; }
        public int IsActive { get; set; }
        public int Level { get; set; }
        public int Slots { get; set; }
    }
}
