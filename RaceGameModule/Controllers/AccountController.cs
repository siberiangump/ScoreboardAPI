using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaceGameModule.Models;
using RaceGameModule.Proxy;

namespace RaceGameModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountProxy AccountProxy;

        public AccountController(AccountProxy proxyService)
        {
            AccountProxy = proxyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> Get()
        {
            return await Task.Run( ()=> AccountProxy.Get());
        }

        [HttpGet("{id:length(24)}", Name = "GetItem")]
        public async Task<ActionResult<Account>> Get(string id)
        {
            var item = await Task.Run(()=> AccountProxy.Get(id));

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
