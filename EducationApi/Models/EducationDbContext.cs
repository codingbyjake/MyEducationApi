using Microsoft.EntityFrameworkCore;

namespace EducationApi.Models {
    public class EducationDbContext : DbContext {

        public DbSet<MAJOR> MAJOR { get; set; } = null!;
        public DbSet<STUDENT> STUDENT { get; set; } = null!;

        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) { }
    }
}
