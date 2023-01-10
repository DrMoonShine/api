
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using Friends_web_api_v1.Models;



namespace Friends_web_api_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEventController : Controller
    {
        ApplicationContext db;
        public UserEventController(ApplicationContext context)
        {
            db = context;
      
        }
        // GET: api/<UserEventController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEvent>>> Get()
        {
            return await db.UserEvents.ToListAsync();
        }

        // GET api/<UserEventController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEvent>> Get(int id)
        {
            UserEvent userEvent = await db.UserEvents.FirstOrDefaultAsync(x => x.Id == id);
            if (userEvent == null)
                return NotFound();
            return new ObjectResult(userEvent);
        }

        [HttpGet("getres")]
        public async Task<ActionResult<IEnumerable<Response>>> GetRes()
        {
            return await db.Responses.ToListAsync();
        }

        [HttpGet("search/{searchName}")]
        public async Task<ActionResult<IEnumerable<UserEvent>>> search(string searchName)
        {
            if(searchName == null)
            {
                return BadRequest();
            }
            return await db.UserEvents.Where(x => x.Name.ToLower().Contains(searchName.Trim().ToLower())).ToListAsync();
        }

        // POST api/<UserEventController>
        [HttpPost]
        public async Task<ActionResult<UserEvent>> Post(UserEvent userEvent)
        {
            if (userEvent == null)
            {
                return BadRequest();
            }

            db.UserEvents.Add(userEvent);
            await db.SaveChangesAsync();
            return Ok(userEvent);
        }

        // PUT api/<UserEventController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserEvent>> Put(UserEvent userEvent)
        {
            if (userEvent == null)
            {
                return BadRequest();
            }
            if (!db.UserEvents.Any(x => x.Id == userEvent.Id))
            {
                return NotFound();
            }

            db.Update(userEvent);
            await db.SaveChangesAsync();
            return Ok(userEvent);
        }

        // DELETE api/<UserEventController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserEvent>> Delete(int id)
        {
            UserEvent userEvent = db.UserEvents.FirstOrDefault(x => x.Id == id);
            if (userEvent == null)
            {
                return NotFound();
            }
            db.UserEvents.Remove(userEvent);
            await db.SaveChangesAsync();
            return Ok(userEvent);
        }
    }
}
