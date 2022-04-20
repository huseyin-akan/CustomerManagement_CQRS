using Microsoft.AspNetCore.Identity;

namespace Core.Persistence.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TCNumber { get; set; }
}
