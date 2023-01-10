using Friends_web_api_v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Friends_web_api_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateEventController : ControllerBase
    {
        ApplicationContext db;
        public CreateEventController(ApplicationContext context)
        {
            db = context;
        }
        [HttpPost("create")]
        public async Task<ActionResult<string>> CreateEvent(UserEvent newEvent)
        {
            
            if (newEvent == null)
            {
                return BadRequest("Event Empty");
            }
            if(newEvent.Creator == null || newEvent.Creator == "default")
            {
                return BadRequest("User Erorr");
            }
            db.UserEvents.Add(newEvent);
            db.SaveChanges();
            return Ok("Ok");
        }

        [HttpPost("response")]
        public async Task<ActionResult<string>> Response(Response eventType)
        {
            if(eventType == null)
            {
                return BadRequest("Erorr");
            }
            db.Responses.Add(eventType);
            db.SaveChanges();
            return Ok("Ok");
        }
    }
}
