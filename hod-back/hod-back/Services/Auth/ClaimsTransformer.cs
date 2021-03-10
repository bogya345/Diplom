//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Identity;

//namespace HeadOfDepartment.Services.Auth
//{
//    public class MyClaimsTransformer : IClaimsTransformer
//    {
//        private UserManager<IdentityUser> _userManager;

//        public MyClaimsTransformer(UserManager<IdentityUser> userManager)
//        {
//            _userManager = userManager;
//        }

//        public async Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
//        {
//            var identity = ((ClaimsIdentity)context.Principal.Identity);

//            // Accessing the UserClaimStore described above
//            var claims = await _userManager.GetClaimsAsync(new IdentityUser(identity.Name));
//            identity.AddClaims(claims);

//            return await Task.FromResult(context.Principal);
//        }
//    }
//}
