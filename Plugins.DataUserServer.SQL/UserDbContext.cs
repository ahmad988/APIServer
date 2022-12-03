using CoreBusinessForUsers;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataUserServer.SQL
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> userTypes { get; set; }
    }
}
