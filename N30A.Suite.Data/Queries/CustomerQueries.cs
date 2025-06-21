namespace N30A.Suite.Data.Queries;

public class CustomerQueries
{
    public const string GetIndividuals = """
        SELECT
            c.id, c.customer_number, c.email, c.phone, c.address, c.postal_code,
            c.city, c.is_active, i.first_name, i.last_name
        FROM customers c 
        JOIN individuals i ON c.id = i.customer_id
        ORDER BY c.id;
    """;
    
    public const string GetIndividualsSearch = """
        SELECT
            c.id, c.customer_number, c.email, c.phone, c.address, c.postal_code,
            c.city, c.is_active, i.first_name, i.last_name
        FROM customers c
        JOIN individuals i ON c.id = i.customer_id
        WHERE c.customer_number = @search
        OR i.full_name ILIKE CONCAT('%', @search, '%')
        OR c.full_address ILIKE CONCAT('%', @search, '%')
        ORDER BY c.id;
    """;
    
    public const string GetCompanies = """
        SELECT
            c.id, c.customer_number, c.email, c.phone, c.address, c.postal_code,
            c.city, c.is_active, co.name, co.org_number
        FROM customers c
        JOIN companies co ON c.id = co.customer_id
        ORDER BY c.id;
    """;
    
    public const string GetCompaniesSearch = """
        SELECT
            c.id, c.customer_number, c.email, c.phone, c.address, c.postal_code,
            c.city, c.is_active, co.name, co.org_number
        FROM customers c
        JOIN companies co ON c.id = co.customer_id
        WHERE c.customer_number = @search
        OR co.name ILIKE CONCAT('%', @search, '%')
        OR c.full_address ILIKE CONCAT('%', @search, '%')
        ORDER BY c.id;
    """;
}
