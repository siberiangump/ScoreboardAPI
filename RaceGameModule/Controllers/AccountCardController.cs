using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaceGameModule.Models;
using RaceGameModule.Proxy;

namespace RaceGameModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCardController : ControllerBase
    {
        private readonly AccountProxy AccountProxy;
        private readonly TrackPregressProxy TrackDataProxy;

        public AccountCardController(AccountProxy proxyService, TrackPregressProxy trackDataProxy)
        {
            AccountProxy = proxyService;
            TrackDataProxy = trackDataProxy;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> Get()
        {
            return await Task.Run(() => AccountProxy.Get());
        }

        [HttpGet("{id:length(24)}", Name = "GetAccount")]
        public async Task<ActionResult<AccountCard>> Get(string id)
        {
            var account = Task.Run(()=>AccountProxy.Get(id));
            var trackProgress = Task.Run(() => TrackDataProxy.FindAllByAccountId(id));
            await Task.WhenAll(account, trackProgress);

            if (account == null)
                return NotFound();

            return new AccountCard(account.Result, trackProgress.Result);
        }

        [HttpPost]
        public async Task<ActionResult<AccountCard>> Create(Account item)
        {
            await Task.Run(() => AccountProxy.Create(item));
            return CreatedAtRoute("GetAccount", new { id = item.Id.ToString() }, item);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Account itemIn)
        {
            var book = await Task.Run(()=> AccountProxy.Get(id));
            if (book == null)
                return NotFound();
            await Task.Run(()=> AccountProxy.Update(id, itemIn));
            return NoContent();
        }
        
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await Task.Run(()=> AccountProxy.Get(id));
            if (book == null)
                return NotFound();
            await Task.Run(() => AccountProxy.Remove(book.Id));

            return NoContent();
        }
    }
}
