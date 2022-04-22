
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? new SuccessResult()  
            : new ErrorResult();  //Result.Failure(result.Errors.Select(e => e.Description));
    }
}
