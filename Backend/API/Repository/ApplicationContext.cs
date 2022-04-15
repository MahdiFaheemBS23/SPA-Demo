using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}