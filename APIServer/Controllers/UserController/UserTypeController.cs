
using APIServer.Model.CoreBusiness.Users;
using APIServer.Model.Plugins.DataStore.User.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIServer.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly UserDbContext dB;

        public UserTypeController(UserDbContext DB)
        {
            dB = DB;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserType>>> GetAllUserType()
        {
            return Ok(await dB.userTypes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserType>> GetUserTypeById(int id)
        {
            var UserTypeInfo = await dB.userTypes.FindAsync(id);
            if (UserTypeInfo == null)
            {
                return NotFound("This UserType Not Found,Please Check Your Information.");
            }
            else
            {
                return Ok(UserTypeInfo);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<UserType>>> AddUserType(UserType userType)
        {
            dB.userTypes.Add(userType);
            await dB.SaveChangesAsync();
            return Ok(dB.userTypes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<UserType>>> UpdateUserType(UserType userType)
        {
            var Info = await dB.userTypes.FindAsync(userType.UserTypeID);
            if (Info == null)
            {
                return NotFound("This UserType Not Found,Please Check Your Information.");
            }
            else
            {
                Info.UserTypeName = userType.UserTypeName;
                await dB.SaveChangesAsync();
                return Ok(await dB.userTypes.ToListAsync());
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserType>>> DeleteUserType(int id)
        {
            var Info = await dB.userTypes.FindAsync(id);
            if (Info == null)
            {
                return NotFound("This UserType Not Found,Please Check Your Information.");
            }
            else
            {
                dB.userTypes.Remove(Info);
                await dB.SaveChangesAsync();
                return Ok(await dB.userTypes.ToListAsync());
            }
        }

    }
}
