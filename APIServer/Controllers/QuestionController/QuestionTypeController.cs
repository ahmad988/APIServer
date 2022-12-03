using APIServer.Model.CoreBusiness.Questions;
using APIServer.Model.Plugins.DataStore.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIServer.Controllers.QuestionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public QuestionTypeController(ApplicationDbContext Db)
        {
            db = Db;
        }
        [HttpGet]
        public async Task<ActionResult<List<QuestionType>>> GetAllQuestionTypes()
        {
            return Ok(await db.questionTypes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionType>> GetQuestionTypeById(int id)
        {
            var info = await db.questionTypes.FindAsync(id);
            if (info == null)
            {
                return NotFound("This QuestionType not Exist,Please Check your Information!");
            }
            else
            {
                return Ok(info);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<QuestionType>>> AddQuestionType(QuestionType questionType)
        {
            db.questionTypes.Add(questionType);
            await db.SaveChangesAsync();
            return Ok(await db.questionTypes.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<QuestionType>>> UpdateQuestionType(QuestionType questionType)
        {
            var info = await db.questionTypes.FindAsync(questionType.QuestionTypeId);
            if (info == null)
            {
                return NotFound("This Question Type not Exist,Please Check your Information!");
            }
            else
            {
                info.QuestionName = questionType.QuestionName;
                info.Type = questionType.Type;
                await db.SaveChangesAsync();
                return Ok(await db.questionTypes.ToListAsync());
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<QuestionType>>> DeleteQuestionType(int id)
        {
            var info = await db.questionTypes.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Question Type not Exist,Please Check your Information!");
            }
            else
            {
                db.questionTypes.Remove(info);
                await db.SaveChangesAsync();
                return Ok(await db.questionTypes.ToListAsync());
            }
        }
    }
}
