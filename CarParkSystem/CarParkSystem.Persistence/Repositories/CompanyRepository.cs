using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CarParkDbContext _context;

        public CompanyRepository(CarParkDbContext context)
        {
            _context = context;
        }
        public int AddCompany(Company c)
        {
            try
            {
                _context.Company.Add(c);
                _context.SaveChanges();
                return c.Id;
            }
            catch (Exception)
            {

                Console.WriteLine("AddCompany exception.");
                return -1;
            }
        }

        public void DeleteCompany(int id)
        {
            try
            {
                var c = _context.Company.FirstOrDefault(x => x.Id == id);
                _context.Company.Remove(c);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                Console.WriteLine("DeleteCompany exception.");
            }

        }
        public void UpdateCompany(Company c)
        {
            try
            {
                var company = _context.Company.FirstOrDefault(x => x.Id == c.Id);
                company.Name = c.Name;
                company.IsValid = c.IsValid;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                Console.WriteLine("UpdateCompany exception");
            }
        }

        public List<Company> GetAllCompany()
        {
            return _context.Company.ToList();
        }

        public void ValidateCompany(int id)
        {
            try
            {
                var c = _context.Company.FirstOrDefault(x => x.Id == id);
                c.IsValid = 1;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("ValidateCompany exception.");
            }
        }
        public void deValidateCompany(int id)
        {
            try
            {
                var c = _context.Company.FirstOrDefault(x => x.Id == id);
                c.IsValid = 0;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                Console.WriteLine("deValidateCompany exception.");
            }
        }
    }
}
