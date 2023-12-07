using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Human_Resource_Management_System
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

    }

}
