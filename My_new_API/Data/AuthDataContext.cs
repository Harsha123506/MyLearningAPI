using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace My_new_API.Data
{
    public class AuthDataContext: IdentityDbContext
    {
        public AuthDataContext(DbContextOptions<AuthDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var readerRoleId = "59485349-6889-4535-abf5-a2e53c3a623c";
            var writerRoleId = "3e1216cf-1fb7-4438-baf2-84c7b34d0987";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    ConcurrencyStamp = readerRoleId,
                    NormalizedName = "READER"
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    ConcurrencyStamp = writerRoleId,
                    NormalizedName = "WRITER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
            // Customizations can be done here if needed
        }
    }
}
