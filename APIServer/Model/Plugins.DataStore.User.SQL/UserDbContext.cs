using APIServer.Model.CoreBusiness.Users;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Model.Plugins.DataStore.User.SQL
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserType> userTypes { get; set; }
    }
}
