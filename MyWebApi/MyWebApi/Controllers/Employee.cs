
using Microsoft.AspNetCore.Mvc;
using MyWebApi.DataBase;
using MyWebApi.Model;


namespace MyWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class Employee : ControllerBase
    {

        private readonly EmployeeDAL _repo;
        public Employee(EmployeeDAL repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Insert(MyModel emp)

        {
            _repo.InsertEmployee(emp);
            return Ok("Employee inserted successfully");
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            // _repo.GetEmployees(id);
            var emp = _repo.GetEmployees(id);
            if (emp == null) return NotFound();
            return Ok(emp);

        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repo.RegisterUser(user);
            return Ok("Registered Successfully");
        }


        [HttpPost("login")]
        public IActionResult Login(LoginDto model)
        {
            _repo.ValidateUserAsync(model);
            return Ok(" inserted successfully");
        }



    }
}
