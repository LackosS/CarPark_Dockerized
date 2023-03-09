using AutoMapper;
using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public int AddCompany(CompanyDTO c)
        {
            var company = _mapper.Map<Company>(c);
            return _repository.AddCompany(company);
        } 

        public void DeleteCompany(int id)
        {
            _repository.DeleteCompany(id);
        }
        public void UpdateCompany(CompanyDTO c)
        {
            var company = _mapper.Map<Company>(c);
            _repository.UpdateCompany(company);
        }
        public List<CompanyDTO> GetAllCompany()
        {
            var companies = _repository.GetAllCompany();
            return _mapper.Map<List<CompanyDTO>>(companies);
        }

        public void ValidateCompany(int id)
        {
            _repository.ValidateCompany(id);
        }
        public void deValidateCompany(int id)
        {
            _repository.deValidateCompany(id);
        }
    }
}
