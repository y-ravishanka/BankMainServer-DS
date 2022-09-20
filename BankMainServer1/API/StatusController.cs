using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankMainServer1.Model;
using BankMainServer1.Data;

namespace BankMainServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private Database db = new();

        [HttpPost]
        [Route("setstatus")]
        public async Task<ActionResult> UpdateStatus(FullStatus tfs)
        {
            try
            {
                FullStatus ffs = db.GetStatus(DateTime.Now.ToString("yyyy/MM/dd"));
                FullStatus dtf = new FullStatus
                {
                    date = ffs.date,
                    deposits = (ffs.deposits + tfs.deposits),
                    damount = (ffs.damount + tfs.damount),
                    withdraws = (ffs.withdraws + tfs.withdraws),
                    wamount = (ffs.wamount + tfs.wamount),
                    balance = (ffs.balance + tfs.balance),
                    newaccounts = (ffs.newaccounts + tfs.newaccounts)
                };
                await UpdateDatabase(dtf);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private async Task UpdateDatabase(FullStatus dtf)
        {
            await Task.Run(() => _ = db.UpdateStatus(new UpdateValue { value = dtf.deposits.ToString(), field = "deposits", nav = dtf.date }));
            await Task.Run(() => _ = db.UpdateStatus(new UpdateValue { value = dtf.deposits.ToString(), field = "deposits", nav = dtf.date }));
            await Task.Run(() => _ = db.UpdateStatus(new UpdateValue { value = dtf.deposits.ToString(), field = "deposits", nav = dtf.date }));
            await Task.Run(() => _ = db.UpdateStatus(new UpdateValue { value = dtf.deposits.ToString(), field = "deposits", nav = dtf.date }));
            await Task.Run(() => _ = db.UpdateStatus(new UpdateValue { value = dtf.deposits.ToString(), field = "deposits", nav = dtf.date }));
            await Task.Run(() => _ = db.UpdateStatus(new UpdateValue { value = dtf.deposits.ToString(), field = "deposits", nav = dtf.date }));
        }
    }
}
