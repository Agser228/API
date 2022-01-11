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
    public class ThematicsController : ControllerBase
    {
        private readonly APIContext _context;

        public ThematicsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Thematics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thematic>>> GetThematic()
        {
            try 
            { 
            return await _context.Thematic.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        // GET: api/Thematics/5
        [HttpGet("{id}")]
        public IActionResult GetThematic(string id)
        {

            try
            {
                int ID = Convert.ToInt32(id);
                var thematic = _context.Thematic.Where(th => th.EventId == ID);

                if (thematic == null)
                {
                    return BadRequest(string.Format("Тематика с id '{0}' не найдена", id));
                }

                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(thematic));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}
