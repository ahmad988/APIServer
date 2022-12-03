using APIServer.Model.CoreBusiness.Answer;
using APIServer.Model.Plugins.DataStore.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIServer.Controllers.ServerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public SurveyController(ApplicationDbContext Db)
        {
            db = Db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Survey>>> GetAllSurveys()
        {
            return Ok(await db.surveys.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurveyById(int id)
        {
            var info = await db.surveys.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Survey not Exist,Please Check your Information!");
            }
            else
            {
                return Ok(info);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Survey>>> AddSurvey(Survey survey)
        {
            db.surveys.Add(survey);
            await db.SaveChangesAsync();
            return Ok(await db.surveys.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Survey>>> UpdateSurvey(Survey survey)
        {
            var info = await db.surveys.FindAsync(survey.SurveyID);
            if (info == null)
            {
                return NotFound("This survey not Exist,Please Check your Information!");
            }
            else
            {
                info.SurveyDate = survey.SurveyDate;
                info.StartTime = survey.StartTime;
                info.EndTime = survey.EndTime;

                await db.SaveChangesAsync();
                return Ok(await db.surveys.ToListAsync());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Survey>>> DeleteSurvey(int id)
        {
            var info = await db.surveys.FindAsync(id);
            if (info == null)
            {
                return NotFound("This Survey not Exist,Please Check your Information!");
            }
            else
            {
                db.surveys.Remove(info);
                await db.SaveChangesAsync();
                return Ok(await db.surveys.ToListAsync());
            }
        }

    }
}
