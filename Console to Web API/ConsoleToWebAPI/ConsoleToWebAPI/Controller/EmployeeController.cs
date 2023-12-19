using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Route("")]
        public EmployeeModel GetEmployees()
        {
            return new EmployeeModel() {Id = 1, Name = "Employee 1"};
        }

        [Route("{id}")]
        public IActionResult GetEmployees(int id)
        {
            if (id == 0) 
            {
                return NotFound();
            }

            return Ok(new List<EmployeeModel> ()
            {
                new EmployeeModel() { Id = 1, Name = "Employee 1" },
                new EmployeeModel() { Id = 2, Name = "Employee 2" },
                new EmployeeModel() { Id = 3, Name = "Employee 3" }
            });
        }

        [Route("{id}/basic")]
        public ActionResult<EmployeeModel> GetEmployeesBasicDetails(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            return new EmployeeModel() { Id = 1, Name = "Employee 1" };

            //return Ok(new List<EmployeeModel>()
            //{
            //    new EmployeeModel() { Id = 1, Name = "Employee 1" },
            //    new EmployeeModel() { Id = 2, Name = "Employee 2" },
            //    new EmployeeModel() { Id = 3, Name = "Employee 3" }
            //});
        }
    }

}
