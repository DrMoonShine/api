using Friends_web_api_v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Friends_web_api_v1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        ApplicationContext db;
        public AuthController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDbo request)
        {
            User userReg = await db.Users.FirstOrDefaultAsync(x => x.NickName == request.NickName);
            if(userReg != null)
            {
                return BadRequest("Not unique");
            }
            User user = new User();

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.NickName = request.NickName;
            user.Name = request.Name;
            user.Email = request.Email;
            user.SecondName = request.SecondName;
            user.Age = request.Age;
            user.TgLink = request.TgLink;
            user.VkLink = request.VkLink;
            user.PhoneNumber = request.PhoneNumber;
            user.Discription = request.Discription;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }
        [HttpGet("{name}/{password}")]
        public async Task<ActionResult<User>> Login(string name, string password)
        {
            
            User userIn = await db.Users.FirstOrDefaultAsync(x => x.NickName == name);
            if (userIn == null)
            {
                return BadRequest("User not found.");
            }
            if (!VerifyPasswordHash(password, userIn.PasswordHash, userIn.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }
            return Ok(userIn);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<User>> GetInfo(string name)
        {

            User userIn = await db.Users.FirstOrDefaultAsync(x => x.NickName == name);
            if (userIn == null)
            {
                return BadRequest("User not found.");
            }
            return Ok(userIn);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            UserEvent userEvent = db.UserEvents.FirstOrDefault(x => x.Id == int.Parse(id));
            if (userEvent == null)
            {
                return NotFound();
            }
            db.UserEvents.Remove(userEvent);
            await db.SaveChangesAsync();
            return Ok(userEvent);
        }
        [HttpPut("update")]
        public async Task<ActionResult<UserEvent>> DataUpdate(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if(user.Id == 0)
            {
                return NotFound("Невырный ID");
            }
            if (!db.UserEvents.Any(x => x.Id == user.Id))
            {
                return NotFound("Пользователя не существует");
            }
            User newDataUser = db.Users.FirstOrDefault(x => x.Id == user.Id);

            newDataUser.Name = user.Name;
            newDataUser.Email = user.Email;
            newDataUser.Age = user.Age;
            newDataUser.TgLink = user.TgLink;
            newDataUser.VkLink = user.VkLink;
            newDataUser.Discription = user.Discription;
            newDataUser.SecondName = user.SecondName;

            db.Update(newDataUser);
            await db.SaveChangesAsync();
            return Ok(newDataUser);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
