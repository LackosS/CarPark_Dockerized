namespace CarParkSystem.Persistence.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public int? CompanyId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public int isValid { get; set; }
    }
}
