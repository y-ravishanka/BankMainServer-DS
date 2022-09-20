using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankMainServer1.Data;
using BankMainServer1.Model;

namespace BankMainServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private Database db = new();

        [HttpGet]
        [Route("getbybranchid/{id:int}")]
        public ActionResult<IEnumerable<Employee>> GetEmployees(int id)
        {
            return db.GetEmployees(1, id);
        }

        [HttpGet]
        [Route("getbyempid/{id}")]
        public ActionResult<Employee> GetEmployee_byid(string id)
        {
            return db.GetEmployees_byNumber(1, id);
        }

        [HttpGet]
        [Route("getbyempnic/{id}")]
        public ActionResult<Employee> GetEmployee_bynic(string id)
        {
            return db.GetEmployees_byNumber(0, id);
        }

        [HttpPost]
        [Route("update/{emp}")]
        public ActionResult UpdateEmployee(Employee emp)
        {
            return NoContent();
        }
    }
}
