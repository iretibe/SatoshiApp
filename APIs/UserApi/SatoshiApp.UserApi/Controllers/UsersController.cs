using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SatoshiApp.UserApi.Models;
using System.Threading.Tasks;

namespace SatoshiApp.UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("CreateUser", Name = "CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var appUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            return Ok(model);
        }
    }
}
