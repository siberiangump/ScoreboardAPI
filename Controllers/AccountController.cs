using System.Collections.Generic;
using core.Models;
using core.Services.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountProxy AccountProxy;
        private readonly TrackPregressProxy TrackDataProxy;

        public AccountController(AccountProxy proxyService, TrackPregressProxy trackDataProxy)
        {
            AccountProxy = proxyService;
            TrackDataProxy = trackDataProxy;
        }

        [HttpGet]
        public ActionResult<List<Account>> Get()
        {
            return AccountProxy.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetItem")]
        public ActionResult<Account> Get(string id)
        {
            var item = AccountProxy.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<Account> Create([FromBody]Account item)
        {
            AccountProxy.Create(item);

            return CreatedAtRoute("GetItem", new { id = item.Id.ToString() }, item);
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
