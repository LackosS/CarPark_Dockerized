namespace CarParkSystem.Persistence.Models
{
    public class UserRegisterModel
    {
        public int CompanyId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Post { get; set; }
    }
}
