using APIServer.Model.CoreBusiness.Users;
using APIServer.Model.Plugins.DataStore.User.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIServer.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext dB;

        public UserController(UserDbContext DB)
        {
            dB = DB;
        }
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            return Ok(await dB.Users.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            var UserInfo = await dB.Users.FirstOrDefaultAsync(x => x.UserID == id);
            if (UserInfo == null)
            {
                return NotFound("This User Not Found,Please Check Your Information.");

            }
            else
            {
                return Ok(UserInfo);
            }
        }
        [HttpGet("{PersonId}")]
        public async Task<ActionResult<Users>> GetUserByPersonId(int PersonId)
        {
            var UserInfo = await dB.Users.FirstOrDefaultAsync(x => x.PersonID == PersonId);
            if (UserInfo == null)
            {
                return NotFound("This User Not Found,Please Check Your Information.");

            }
            else
            {
                return Ok(UserInfo);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Users>>> AddUser(Users user)
        {
            dB.Users.Add(user);
            await dB.SaveChangesAsync();
            return Ok(await dB.Users.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Users>>> UpdetUser(Users user)
        {
            var UserInfo = await dB.Users.FirstOrDefaultAsync(x => x.UserID == user.UserID);
            if (UserInfo == null)
            {
                return NotFound("This User Not Found,Please Check Your Information.");

            }
            else
            {
                UserInfo.Username = user.Username;
                UserInfo.Password = user.Password;
                UserInfo.UserTypeID = user.UserID;
                UserInfo.PersonID = user.PersonID;
                await dB.SaveChangesAsync();
                return Ok(await dB.Users.ToListAsync());
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Users>>> DeleteUser(int id)
        {
            var UserInfo = await dB.Users.FirstOrDefaultAsync(x => x.UserID == id);
            if (UserInfo == null)
            {
                return NotFound("This User Not Found,Please Check Your Information.");
            }
            else
            {
                dB.Users.Remove(UserInfo);
                await dB.SaveChangesAsync();
                return Ok(await dB.Users.ToListAsync());
            }
        }
        [HttpDelete("{Personid}")]

        public async Task<ActionResult<List<Users>>> DeleteUserByPersonID(int Personid)
        {
            var UserInfo = await dB.Users.FirstOrDefaultAsync(x => x.PersonID == Personid);
            if (UserInfo == null)
            {
                return NotFound("This User Not Found,Please Check Your Information.");
            }
            else
            {
                dB.Users.Remove(UserInfo);
                await dB.SaveChangesAsync();
                return Ok(await dB.Users.ToListAsync());
            }
        }
    }
}
