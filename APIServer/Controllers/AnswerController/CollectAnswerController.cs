using APIServer.Model.CoreBusiness.Answer;
using APIServer.Model.Plugins.DataStore.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Controllers.AnswerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectAnswerController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public CollectAnswerController(ApplicationDbContext Db)
        {
            db = Db;
        }
        [HttpGet]
        public async Task<ActionResult<List<CollectAnswer>>> GetAllCollectAnswers()
        {
            return Ok(await db.collectAnswers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollectAnswer>> GetCollectAnswerById(int id)
        {
            var info = await db.collectAnswers.FindAsync(id);
            if (info == null)
            {
                return NotFound("This CollectAnswer not Exist,Please Check your Information!");
            }
            else
            {
                return Ok(info);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<CollectAnswer>>> AddCollectAnswer(CollectAnswer collectAnswer)
        {
            db.collectAnswers.Add(collectAnswer);
            await db.SaveChangesAsync();
            return Ok(await db.collectAnswers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<CollectAnswer>>> UpdateCollectAnswer(CollectAnswer collectAnswer)
        {
            var info = await db.collectAnswers.FindAsync(collectAnswer.CollectAnswerID);
            if (info == null)
            {
                return NotFound("This Collect Answer not Exist,Please Check your Information!");
            }
            else
            {
                info.ProjectID = collectAnswer.ProjectID;
                info.QuestionID = collectAnswer.QuestionID;
                info.AnswerID = collectAnswer.AnswerID;
                info.AnswerText = collectAnswer.AnswerText;
                info.SurveyID = collectAnswer.SurveyID;
                await db.SaveChangesAsync();
                return Ok(await db.collectAnswers.ToListAsync());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CollectAnswer>>> DeleteCollectAnswer(int id)
        {
            var info = await db.collectAnswers.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Collect Answer not Exist,Please Check your Information!");
            }
            else
            {
                db.collectAnswers.Remove(info);
                await db.SaveChangesAsync();
                return Ok(await db.collectAnswers.ToListAsync());
            }
        }
    }
}
