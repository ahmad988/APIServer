using APIServer.Model.CoreBusiness;
using APIServer.Model.Plugins.DataStore.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIServer.Controllers.ProjectController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext dB;

        public CategoryController(ApplicationDbContext DB)
        {
            dB = DB;
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategory()
        {
            return Ok(await dB.categories.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var info = await dB.categories.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Category not Exist,Please Check your Information!");
            }
            else
            {
                return Ok(info);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            dB.categories.Add(category);
            await dB.SaveChangesAsync();
            return Ok(await dB.categories.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category category)
        {
            var info = await dB.categories.FindAsync(category.CatID);
            if (info == null)
            {
                return NotFound("This Category not Exist,Please Check your Information!");
            }
            else
            {
                info.Name = category.Name;
                info.Description = category.Description;
                await dB.SaveChangesAsync();
                return Ok(await dB.categories.ToListAsync());
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var info = await dB.categories.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Category not Exist,Please Check your Information!");
            }
            else
            {
                dB.categories.Remove(info);
                await dB.SaveChangesAsync();
                return Ok(await dB.categories.ToListAsync());
            }
        }
    }
}
