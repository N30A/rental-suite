using N30A.Suite.Data.Models;

namespace N30A.Suite.Data.Repositories.Interfaces;

public interface ICustomerRepository
{   
    Task<DbResult<IEnumerable<IndividualModel>>> GetIndividuals(string? search = null);
    Task<DbResult<IndividualModel>> GetIndividualById(int id);
    Task<DbResult<IndividualModel>> GetIndividualByCustomerNumber(string customerNumber);
    
    Task<DbResult<IEnumerable<CompanyModel>>> GetCompanies(string? search = null);
    Task<DbResult<CompanyModel>> GetCompanyById(int id);
    Task<DbResult<CompanyModel>> GetCompanyByCustomerNumber(string customerNumber);
}
