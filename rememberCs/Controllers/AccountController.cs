using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


    }
}
