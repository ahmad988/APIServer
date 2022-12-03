
using Microsoft.EntityFrameworkCore;
using APIServer.Model.CoreBusiness;
using APIServer.Model.CoreBusiness.Questions;
using APIServer.Model.CoreBusiness.Answer;

namespace APIServer.Model.Plugins.DataStore.SQL
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<QuestionType> questionTypes { get; set; }
        public DbSet<Answer> answers { get; set; }
        public DbSet<CollectAnswer> collectAnswers { get; set; }
        public DbSet<Survey> surveys { get; set; }
    }
}
