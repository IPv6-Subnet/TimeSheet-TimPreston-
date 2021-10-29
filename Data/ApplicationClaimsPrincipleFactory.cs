using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data
{
    /*
  public class ApplicationClaimsPrincipleFactory : UserClaimsPrincipalFactory<Employee, IdentityRole>
  {

      public ApplicationClaimsPrincipleFactory(
          UserManager<Employee> userManager
          , RoleManager<IdentityRole> roleManager
          , IOptions<IdentityOptions> optionsAccessor)
      : base(userManager, roleManager, optionsAccessor)
      { }

      public async override Task<ClaimsPrincipal> CreateAsync(Employee user)
      {
          var principal = await base.CreateAsync(user);
          if (!string.IsNullOrWhiteSpace(user.FirstName))
          {
                  ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
              new Claim(ClaimTypes.GivenName, user.FirstName)
            });
          }

          if (!string.IsNullOrWhiteSpace(user.LastName))
          {
                  ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
              new Claim(ClaimTypes.Surname, user.LastName),
            });
          }
          return principal;
      }
      
}
    */
}
