using APIServer.Model.CoreBusiness.Questions;
using APIServer.Model.Plugins.DataStore.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIServer.Controllers.QuestionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public QuestionController(ApplicationDbContext Db)
        {
            db = Db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Question>>> GetAllQuestions()
        {
            return Ok(await db.questions.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestionById(int id)
        {
            var info = await db.questions.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Question not Exist,Please Check your Information!");
            }
            else
            {
                return Ok(info);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Question>>> AddQuestion(Question question)
        {
            db.questions.Add(question);
            await db.SaveChangesAsync();
            return Ok(await db.questions.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Question>>> UpdateQuestion(Question question)
        {
            var info = await db.questions.FindAsync(question.QuestionID);
            if (info == null)
            {
                return NotFound("This Question not Exist,Please Check your Information!");
            }
            else
            {
                info.ProjectID = question.ProjectID;
                info.QuestionTypeID = question.QuestionTypeID;
                info.QuestionTitle = question.QuestionTitle;
                info.Description = question.Description;

                await db.SaveChangesAsync();
                return Ok(await db.questions.ToListAsync());
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Question>>> DeleteQuestion(int id)
        {
            var info = await db.questions.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Question not Exist,Please Check your Information!");
            }
            else
            {
                db.questions.Remove(info);
                await db.SaveChangesAsync();
                return Ok(await db.questions.ToListAsync());
            }
        }

    }
}
