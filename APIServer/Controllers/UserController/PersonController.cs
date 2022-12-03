using APIServer.Model.CoreBusiness.Users;
using APIServer.Model.Plugins.DataStore.User.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIServer.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly UserDbContext userDb;

        public PersonController(UserDbContext UserDb)
        {
            userDb = UserDb;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPerson()
        {
            return Ok(await userDb.People.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var PersonInfo = await userDb.People.FindAsync(id);
            if (PersonInfo == null)
            {
                return NotFound("This Person is not Exist! Please Check your Information!");
            }
            else
            {
                return Ok(PersonInfo);
            }
        }
        //Add
        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson(Person P)
        {
            userDb.People.Add(P);
            await userDb.SaveChangesAsync();
            return Ok(await userDb.People.ToListAsync());
        }

        //Update
        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person P)
        {
            var PersonInfo = await userDb.People.FindAsync(P.Id);
            if (PersonInfo == null)
            {
                return NotFound("This Person is not Exist! Please Check your Information!");
            }
            else
            {
                PersonInfo.FirstName = P.FirstName;
                PersonInfo.LastName = P.LastName;
                PersonInfo.Birthday = P.Birthday;
                PersonInfo.Phone = P.Phone;
                PersonInfo.Email = P.Email;
                PersonInfo.Country = P.Country;
                PersonInfo.City = P.City;

                await userDb.SaveChangesAsync();
                return Ok(await userDb.People.ToListAsync());

            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var PersonInfo = await userDb.People.FindAsync(id);
            if (PersonInfo == null)
            {
                return NotFound("This Person is not Exist! Please Check your Information!");
            }
            else
            {
                userDb.People.Remove(PersonInfo);
                await userDb.SaveChangesAsync();
                return Ok(await userDb.People.ToListAsync());
            }
        }
    }
}
