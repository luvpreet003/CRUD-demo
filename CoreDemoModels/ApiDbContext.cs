using Microsoft.EntityFrameworkCore;

namespace CoreDemoModels
{
    public class ApiDbContext : DbContext
    { 
        public virtual DbSet<SchoolsDTO> Schools { get; set; }

        public virtual DbSet<StudentsDTO> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= MPL-46ZZ573\\SQLEXPRESS; Database= Demo2024; Trusted_Connection = True");
        }
    }
}
