namespace N30A.Suite.Data.Models;

public class IndividualModel
{
    public int Id { get; set; }
    public string CustomerNumber { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public bool IsActive { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
