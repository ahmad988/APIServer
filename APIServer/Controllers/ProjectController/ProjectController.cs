using APIServer.Model.CoreBusiness;
using APIServer.Model.Plugins.DataStore.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIServer.Controllers.ProjectController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ProjectController(ApplicationDbContext Db)
        {
            db = Db;
        }


        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            return Ok(await db.projects.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            var info = await db.projects.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Project not Exist,Please Check your Information!");
            }
            else
            {
                return Ok(info);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(Project project)
        {
            db.projects.Add(project);
            await db.SaveChangesAsync();
            return Ok(await db.projects.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Project>>> UpdateProject(Project project)
        {
            var info = await db.projects.FindAsync(project.ProjectID);
            if (info == null)
            {
                return NotFound("This Project not Exist,Please Check your Information!");
            }
            else
            {
                info.CategoryID = project.CategoryID;
                info.ProjectName = project.ProjectName;
                info.Location = project.Location;
                info.Phone = project.Phone;
                info.EmailAddress = project.EmailAddress;
                info.Website = project.Website;
                await db.SaveChangesAsync();
                return Ok(await db.projects.ToListAsync());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Project>>> DeleteProject(int id)
        {
            var info = await db.projects.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Project not Exist,Please Check your Information!");
            }
            else
            {
                db.projects.Remove(info);
                await db.SaveChangesAsync();
                return Ok(await db.projects.ToListAsync());
            }
        }

    }
}
