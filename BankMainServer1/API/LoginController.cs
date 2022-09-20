using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankMainServer1.Data;
using BankMainServer1.Model;

namespace BankMainServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private Database database = new();

        [HttpGet]
        [Route("getlogininfor/{nic}")]
        public ActionResult<ClientLogin> GetLogins(string nic)
        {
            try
            {
                return database.GetLogin(nic);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
