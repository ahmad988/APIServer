
using APIServer.Model.CoreBusiness.Answer;
using APIServer.Model.Plugins.DataStore.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIServer.Controllers.AnswerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public AnswerController(ApplicationDbContext Db)
        {
            db = Db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Answer>>> GetAllAnswers()
        {
            return Ok(await db.answers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswerById(int id)
        {
            var info = await db.answers.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Answer not Exist,Please Check your Information!");
            }
            else
            {
                return Ok(info);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Answer>>> AddAnswer(Answer answer)
        {
            db.answers.Add(answer);
            await db.SaveChangesAsync();
            return Ok(await db.answers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Answer>>> UpdateAnswer(Answer answer)
        {
            var info = await db.answers.FindAsync(answer.AnswerID);
            if (info == null)
            {
                return NotFound("This Answer not Exist,Please Check your Information!");
            }
            else
            {
                info.QuestionID = answer.QuestionID;
                info.Text = answer.Text;
                await db.SaveChangesAsync();
                return Ok(await db.answers.ToListAsync());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Answer>>> DeleteAnswer(int id)
        {
            var info = await db.answers.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Answer not Exist,Please Check your Information!");
            }
            else
            {
                db.answers.Remove(info);
                await db.SaveChangesAsync();
                return Ok(await db.answers.ToListAsync());
            }
        }
    }
}
