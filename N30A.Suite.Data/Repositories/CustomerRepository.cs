using System.Data;
using Dapper;
using N30A.Suite.Data.Exceptions;
using N30A.Suite.Data.Models;
using N30A.Suite.Data.Queries;
using N30A.Suite.Data.Repositories.Interfaces;

namespace N30A.Suite.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{   
    private readonly IDbConnection _connection;
    
    public CustomerRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<DbResult<IEnumerable<IndividualModel>>> GetIndividuals(string? search = null)
    {
        try
        {
            string query = search == null
                ? CustomerQueries.GetIndividuals
                : CustomerQueries.GetIndividualsSearch;

            var customers = await _connection.QueryAsync<IndividualModel>(query);
            return DbResult<IEnumerable<IndividualModel>>.Success(customers);
        }
        catch (Exception)
        {
            return DbResult<IEnumerable<IndividualModel>>.Failure();
        }
    }

    public async Task<DbResult<IndividualModel>> GetIndividualById(int id)
    {
        try
        {
            var customer = await _connection.QuerySingleOrDefaultAsync<IndividualModel>(
                CustomerQueries.GetIndividualById, new { Id = id }
            );
            return customer == null
                ? DbResult<IndividualModel>.Failure(exception: new NotFoundException())
                : DbResult<IndividualModel>.Success(customer);
        }
        catch (Exception)
        {
            return DbResult<IndividualModel>.Failure();
        }
    }

    public async Task<DbResult<IndividualModel>> GetIndividualByCustomerNumber(string customerNumber)
    {
        try
        {
            var customer = await _connection.QuerySingleOrDefaultAsync<IndividualModel>(
                CustomerQueries.GetIndividualByCustomerNumber, new { CcustomerNumber = customerNumber }
            );
            return customer == null
                ? DbResult<IndividualModel>.Failure(exception: new NotFoundException())
                : DbResult<IndividualModel>.Success(customer);
        }
        catch (Exception)
        {
            return DbResult<IndividualModel>.Failure();
        }
    }

    public async Task<DbResult<IEnumerable<CompanyModel>>> GetCompanies(string? search = null)
    {
        try
        {
            string query = search == null
                ? CustomerQueries.GetCompanies
                : CustomerQueries.GetCompaniesSearch;

            var customers = await _connection.QueryAsync<CompanyModel>(query);
            return DbResult<IEnumerable<CompanyModel>>.Success(customers);
        }
        catch (Exception)
        {
            return DbResult<IEnumerable<CompanyModel>>.Failure();
        }
    }

    public async Task<DbResult<CompanyModel>> GetCompanyById(int id)
    {
        try
        {
            var customer = await _connection.QuerySingleOrDefaultAsync<CompanyModel>(
                CustomerQueries.GetIndividualById, new { Id = id }
            );
            return customer == null
                ? DbResult<CompanyModel>.Failure(exception: new NotFoundException())
                : DbResult<CompanyModel>.Success(customer);
        }
        catch (Exception)
        {
            return DbResult<CompanyModel>.Failure();
        }
    }

    public async Task<DbResult<CompanyModel>> GetCompanyByCustomerNumber(string customerNumber)
    {
        try
        {
            var customer = await _connection.QuerySingleOrDefaultAsync<CompanyModel>(
                CustomerQueries.GetCompanyByCustomerNumber, new { CcustomerNumber = customerNumber }
            );
            return customer == null
                ? DbResult<CompanyModel>.Failure(exception: new NotFoundException())
                : DbResult<CompanyModel>.Success(customer);
        }
        catch (Exception)
        {
            return DbResult<CompanyModel>.Failure();
        }
    }
}
