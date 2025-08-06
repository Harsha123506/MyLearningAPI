using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace My_new_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] students = ["rinj", "isbi", "vube", "iuebc"];
            return Ok(students);
        }
    }
}
