using Microsoft.EntityFrameworkCore;

namespace EducationApi.Models {
    public class EducationDbContext : DbContext {

        public DbSet<MAJOR> MAJOR { get; set; }
        public DbSet<STUDENT> STUDENT { get; set; }

        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) { }
    }
}
