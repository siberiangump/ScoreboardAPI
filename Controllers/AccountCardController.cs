using System.Collections.Generic;
using core.Models;
using core.Services.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core.Controllers
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
        public ActionResult<List<Account>> Get()
        {
            return AccountProxy.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetAccount")]
        public ActionResult<AccountCard> Get(string id)
        {
            var account = AccountProxy.Get(id);
            if (account == null)
            {
                return NotFound();
            }
            var trackProgress = TrackDataProxy.FindAllByAccountId(id);
            return new AccountCard(account, trackProgress);
        }

        [HttpPost]
        public ActionResult<AccountCard> Create(Account item)
        {
            AccountProxy.Create(item);
            return CreatedAtRoute("GetAccount", new { id = item.Id.ToString() }, item);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Account itemIn)
        {
            var book = AccountProxy.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            AccountProxy.Update(id, itemIn);

            return NoContent();
        }
        
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = AccountProxy.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            AccountProxy.Remove(book.Id);

            return NoContent();
        }
    }
}
