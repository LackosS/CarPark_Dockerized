using CarParkSystem.Persistence.DTO;

namespace CarParkSystem.Interfaces
{
    public interface ICompanyService
    {
        int AddCompany(CompanyDTO c);
        void DeleteCompany(int id);
        List<CompanyDTO> GetAllCompany();
        void UpdateCompany(CompanyDTO c);
        void ValidateCompany(int id);
        void deValidateCompany(int id);

    }
}
