namespace N30A.Suite.Data.Models;

public class CompanyModel
{
    public int Id { get; set; }
    public string CustomerNumber { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public bool IsActive { get; set; }
    
    public string Name { get; set; }
    public string OrgNumber { get; set; }
}
