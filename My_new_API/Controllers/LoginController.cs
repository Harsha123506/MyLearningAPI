using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_new_API.Data;

namespace My_new_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly DataContext _dataContext;
        public LoginController(DataContext dataContext) {
            _dataContext = dataContext;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> ValidateUser(string username, string password)
        {

            return Ok("Login SuccessFull");   
        }
    }
}
