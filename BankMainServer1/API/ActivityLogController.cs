using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankMainServer1.Data;
using BankMainServer1.Model;

namespace BankMainServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        Database database = new();
        //[HttpGet]
        //public IEnumerable<ActivityLog> Get()
        //{
        //    Database database = new Database();
        //    List<ActivityLog> list = database.GetActivityLogs(0, 0);
        //    ActivityLog[] log = new ActivityLog[list.Count];
        //    int i = 0;
        //    foreach (ActivityLog logItem in list)
        //    {
        //        log[i] = logItem;
        //        ++i;
        //    }
        //    return log;
        //}

        [HttpGet]
        public IEnumerable<ActivityLog> Get()
        {
            return database.GetActivityLogs(0, 0);
        }
    }
}
