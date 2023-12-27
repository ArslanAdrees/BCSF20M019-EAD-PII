using Microsoft.EntityFrameworkCore;
using Student_Interest_System.Models;
using Student_Interest_System.Models.Domain;

namespace Student_Interest_System.Data
{
    public class StudentInterestDbContext : DbContext
    {
        public StudentInterestDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
