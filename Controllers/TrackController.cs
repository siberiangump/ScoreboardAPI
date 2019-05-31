using System.Collections.Generic;
using core.Models;
using core.Services.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly TrackPregressProxy TrackDataProxy;

        public TrackController(TrackPregressProxy trackDataProxy)
        {
            TrackDataProxy = trackDataProxy;
        }

        [HttpGet]
        public ActionResult<List<TrackProgress>> Get()
        {
            return TrackDataProxy.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetTrack")]
        public ActionResult<TrackProgress> Get(string id)
        {
            var trackProgress = TrackDataProxy.Get(id);
            if (trackProgress == null)
            {
                return NotFound();
            }
            return trackProgress;
        }

        [HttpPost]
        public ActionResult<TrackProgress> Create(TrackProgress item)
        {
            TrackDataProxy.Create(item);
            return CreatedAtRoute("GetTrack", new { id = item.Id.ToString() }, item);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, TrackProgress itemIn)
        {
            var book = TrackDataProxy.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            TrackDataProxy.Update(id, itemIn);

            return NoContent();
        }
    }
}
