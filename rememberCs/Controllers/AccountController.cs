using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rememberCs.Helpers;
using rememberCs.Models.DataModels;

namespace rememberCs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        private IEnumerable<Users> Loggings = new List<Users>() {

            new Users()
            {
                Id =1,
                Email="Oscarm.lavareg@gmail.com",
                Name = "admon",
                lastname = "el mejor :)"
            },
            new Users()
            {
                Id =2,
                Email="pepemujica.lavareg@gmail.com",
                Name = "Julian",
                lastname = "el mejor :)"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLoggins userLoggins)
        {
            try {

                var Token = new UserTokens();
                var Valid = Loggings.Any(user => user.Name.Equals(userLoggins.userName, StringComparison.OrdinalIgnoreCase));

                if (Valid)
                {
                    var user = Loggings.FirstOrDefault(user => user.Name.Equals(userLoggins.userName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.Name,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuId = Guid.NewGuid()
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Credentials");
                }
                return Ok(Token);

            }
            catch(Exception ex) {

                throw new Exception("Get Token error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Loggings);
        }

    }
}
