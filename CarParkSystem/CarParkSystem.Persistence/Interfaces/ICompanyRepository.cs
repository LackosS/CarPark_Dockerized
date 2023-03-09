using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Interfaces
{
    public interface ICompanyRepository
    {
        public int AddCompany(Company c);
        public void ValidateCompany(int id);
        public void DeleteCompany(int id);
        public List<Company> GetAllCompany();
        public void deValidateCompany(int id);
        void UpdateCompany(Company c);
    }
}
