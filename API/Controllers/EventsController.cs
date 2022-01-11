using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly APIContext _context;

        public EventsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<IActionResult> GetEventAsync()
        {
            try
            {
                var exp =  await _context.Event.ToListAsync();
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(exp));
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Events/5

        [HttpGet("{id}")]
        public IActionResult GetEvent(string id)
        {
            try 
            {
                int ID = Convert.ToInt32(id);
                var @event =  _context.Event.Find(ID);

                if (@event == null)
                {
                    return BadRequest(string.Format("Праздник с id '{0}' не найден", ID));
                }
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(@event));

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
