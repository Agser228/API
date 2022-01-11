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
    public class CongratulationsController : ControllerBase
    {
        private readonly APIContext _context;

        public CongratulationsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Congratulations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Congratulation>>> GetCongratulation()
        {
            try
            {
                return await _context.Congratulation.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Congratulations/5
        [HttpGet("{id}")]
        public IActionResult GetCongratulation(string id)
        {
            try
            {
                int ID = Convert.ToInt32(id);
                var congratulation = _context.Congratulation.Where(th => th.ThematicId == ID);

                if (congratulation == null)
                {
                    return BadRequest(string.Format("Поздравление с id '{0}' не найдено", id));
                }

                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(congratulation));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }
    }
}
