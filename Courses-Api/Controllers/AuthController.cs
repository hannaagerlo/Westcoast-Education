using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Courses_Api.Helpers.UserHelper;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Authorization;
using Courses_Api.ViewModel.Student;
using Courses_Api.ViewModel.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Courses_Api.Controllers

{
  [ApiController]
  [Route("api/v1/auth")]
  public class AuthController : ControllerBase
  {
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signManager;
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepo;
    private readonly IUserHelper _userHelper;

    public AuthController(IConfiguration config, UserManager<User> userManager, SignInManager<User> signInManager, 
    RoleManager<IdentityRole> roleManager, IUserRepository userRepo,IUserHelper userHelper)
    {
      _roleManager = roleManager;
      _userManager = userManager;
      _signManager = signInManager;
      _config = config;
      _userRepo = userRepo;
      _userHelper = userHelper;
    }

     [HttpGet("getLoggedInUser")]
      public UserViewModel? LoggedInUser()
      {
        return _userHelper.LoggedInUser();
      }

      [HttpGet("list")]
        public async Task<ActionResult<List<UserViewModel>>> ListAdmins()
        {
             return Ok(await _userRepo.ListAllAdminsAsync());        
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserViewModel>> LoginAsync(LoginViewModel model)
        {
          // var user = await _userManager.FindByEmailAsync(model.Email);
           var user = await _userManager.FindByNameAsync(model.UserName);
          if (user is null)
          return Unauthorized("Felaktigt användarnamn");

          var result = await _signManager.CheckPasswordSignInAsync(user, model.Password, false);
          if(!result.Succeeded)
          return Unauthorized();
          user.EmailConfirmed = true;

          user.IsLoggedIn = true;
          var userData = new UserAuthViewModel
          {
            // Email = user.UserName,
            UserName = user.UserName,
            Expires = DateTime.Now.AddDays(7),
            Token = await CreateJwtToken(user),
            IsLoggedIn = true

          };

          return Ok(userData);
          // return Ok("Användaren är inloggad");

        }

        [HttpPost("logout")]
        public async Task<ActionResult> LogoutAsync()
        {
          // if(User.Identity.IsAuthenticated)
          // {
          //   await _signManager.SignOutAsync();
          //     return Ok("Användaren är utloggad");
          // }
          //  return Unauthorized("Ingen användare inloggad");
          if (_signManager.IsSignedIn(User))
          {
              await _signManager.SignOutAsync();
              return Ok("Användaren är utloggad");
          }
          return Unauthorized("Ingen användare inloggad");

          // await _signManager.SignOutAsync(); 
          // return Ok("Användaren är utloggad");

        }

        [HttpGet("GetSignedInUser")]
        public async Task<ActionResult> GetSignedInUserAsync()
        {

          if(User.Identity.IsAuthenticated)
          {
              return Ok("Användare är inloggad");
          }
           return Unauthorized("Ingen användare inloggad");

          // if (_signManager.IsSignedIn(User))
          // {
          //     return Ok("Användaren är inloggad");
          // }
          // return Unauthorized("Ingen användare inloggad");

          // await _signManager.SignOutAsync(); 
          // return Ok("Användaren är utloggad");

        }

         [HttpPost("register")]
        public async Task<ActionResult> RegisterAdminAsync(PostUserViewModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.Email);
            if (userExist != null)
            {
                return StatusCode(500, "Användaren finns redan");
            }
            var user = new User{
                Email = model.Email!.ToLower(),
                UserName = model.Email!.ToLower(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Street = model.Street,
                StreetNumber = model.StreetNumber,
                City = model.City,
                PostalCode = model.PostalCode
            };

            var studentToAdd = await _userManager.CreateAsync(user, model.Password);
            if(!studentToAdd.Succeeded)
            {
                 return StatusCode(500, "Det gick inte att spara användaren");
            }
              if (!await _roleManager.RoleExistsAsync(UserRole.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
            }

            if (await _roleManager.RoleExistsAsync(UserRole.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRole.Admin);
            }

            //  var userData = new UserAuthViewModel
            // {
            //     Email = user.UserName,
            // };
               var userData = new UserAuthViewModel
            {
                UserName = user.UserName,
                Token = await CreateJwtToken(user)
            };

            return Ok("Användaren är sparad");

        }
         private async Task<string> CreateJwtToken(User user)
        {
          var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("apiKey"));
          var userClaims = (await _userManager.GetClaimsAsync(user)).ToList();

          var jwt = new JwtSecurityToken(
              claims: userClaims,
              notBefore: DateTime.Now,
              expires: DateTime.Now.AddDays(7),
              signingCredentials: new SigningCredentials(
                  new SymmetricSecurityKey(key),
                  SecurityAlgorithms.HmacSha512Signature
              )
          );
          return new JwtSecurityTokenHandler().WriteToken(jwt);
        }        

//     [HttpPost("registerStudent")]
//     public async Task<ActionResult<PostStudentViewModel>> RegisterUser(RegisterUserViewModel model)
//     {
//       var user = new IdentityUser
//       {
//         Email = model.EmailAdress!.ToLower(),
//         UserName = model.EmailAdress.ToLower()
//       };

//       var result = await _userManager.CreateAsync(user, model.Password);

//       if (result.Succeeded)
//       {
//         if (model.IsAdmin)
//         {
//           await _userManager.AddClaimAsync(user, new Claim("Admin", "true"));
//         }

//         await _userManager.AddClaimAsync(user, new Claim("User", "true"));
//         await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));

//         var userData = new StudentViewModel
//         {
//           EmailAdress = user.Email,
//           Token = await CreateJwtToken(user)
//         };

//         return StatusCode(201, userData);
//       }
//       else
//       {
//         foreach (var error in result.Errors)
//         {
//           ModelState.AddModelError("User registration", error.Description);
//         }
//         return StatusCode(500, ModelState);
//       }
//     }

//     [HttpPost("loginStudent")]
//     [AllowAnonymous]
//     public async Task<ActionResult<StudentViewModel>> Login(LoginViewModel model)
//     {
//       var user = await _userManager.FindByNameAsync(model.EmailAdress);

//       if (user is null)
//         return Unauthorized("Felaktigt e-post");

//       var result = await _signManager.CheckPasswordSignInAsync(user, model.Password, false);

//       if (!result.Succeeded)
//         return Unauthorized();

//       var userData = new StudentViewModel
//       {
//         EmailAdress = user.Email,
//         Expires = DateTime.Now.AddDays(7),
//         Token = await CreateJwtToken(user)
//       };

//       return Ok(userData);
//     }

// [HttpPost("registerAdmin")]
//     public async Task<ActionResult<AdminViewModel>> RegisterAdmin(RegisterAdminViewModel model)
//     {
//       var user = new IdentityUser
//       {
//         Email = model.EmailAdress!.ToLower(),
//         UserName = model.EmailAdress.ToLower()
//       };

//       var result = await _userManager.CreateAsync(user, model.Password);

//       if (result.Succeeded)
//       {
//         if (model.IsAdmin)
//         {
//           await _userManager.AddClaimAsync(user, new Claim("Admin", "true"));
//         }

//         await _userManager.AddClaimAsync(user, new Claim("User", "true"));
//         await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));

//         var userData = new AdminViewModel
//         {
//           EmailAdress = user.Email,
//           Token = await CreateJwtToken(user)
//         };

//         return StatusCode(201, userData);
//       }
//       else
//       {
//         foreach (var error in result.Errors)
//         {
//           ModelState.AddModelError("User registration", error.Description);
//         }
//         return StatusCode(500, ModelState);
//       }
//     }

//     [HttpPost("loginAdmin")]
//     [AllowAnonymous]
//     public async Task<ActionResult<AdminViewModel>> LoginAdmin(LoginAdminViewModel model)
//     {
//       var user = await _userManager.FindByNameAsync(model.EmailAdress);

//       if (user is null)
//         return Unauthorized("Felaktigt e-post");

//       var result = await _signManager.CheckPasswordSignInAsync(user, model.Password, false);

//       if (!result.Succeeded)
//         return Unauthorized();

//       var userData = new AdminViewModel
//       {
//         EmailAdress = user.Email,
//         Expires = DateTime.Now.AddDays(7),
//         Token = await CreateJwtToken(user)
//       };

//       return Ok(userData);
//     }
//     private async Task<string> CreateJwtToken(IdentityUser user)
//     {
//       var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("apiKey"));
//       var userClaims = (await _userManager.GetClaimsAsync(user)).ToList();

//       var jwt = new JwtSecurityToken(
//           claims: userClaims,
//           notBefore: DateTime.Now,
//           expires: DateTime.Now.AddDays(7),
//           signingCredentials: new SigningCredentials(
//               new SymmetricSecurityKey(key),
//               SecurityAlgorithms.HmacSha512Signature
//           )
//       );
//       return new JwtSecurityTokenHandler().WriteToken(jwt);
//     }
  }
}
