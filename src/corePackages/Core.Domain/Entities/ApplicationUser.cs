using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TCNumber { get; set; }
    public bool Status { get; set; }
}
