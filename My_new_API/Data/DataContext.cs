using Microsoft.EntityFrameworkCore;
using My_new_API.Models;

namespace My_new_API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> contextOptions):base(contextOptions) { 
            

        }

        public DbSet<Difficulty> difficulties {  get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> walks { get; set; }
        public DbSet<Image> images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulty = new List<Difficulty>()
            {
               new Difficulty() { 
                    Id = Guid.Parse("a71142f7-7059-4fc3-8fd8-8e85711d808c"),
                    Name = "Easy"
                },
               new Difficulty() {
                    Id = Guid.Parse("4efe3c60-a3d2-4570-b20f-8ed8dd8f53d0"),
                    Name = "Medium"
                },
               new Difficulty() {
                    Id = Guid.Parse("fd19b7a2-558a-44e2-81c0-44481088558a"),
                    Name = "Hard"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulty); //will create data in database

            var regions = new List<Region>()
            {
                 new Region()
                {
                     Id = Guid.Parse("6008a2a4-c3f1-48d7-90c1-3ae57bdbc710"),
                     Name = "India",
                     Code = "IND",
                     ImageUrl = "https://www.gettyimages.in/detail/illustration/india-map-royalty-free-illustration/1147562559?adppopup=true"

                },
                  new Region()
                {
                    Id = Guid.Parse("2a75c676-0cfd-434b-b4c4-eff4475c33d8"),
                     Name = "Canada",
                     Code = "CND",
                     ImageUrl = "https://www.alamy.com/stock-photo/canada-map.html?sortBy=relevant"
                },
                  new Region()
                {
                     Id = Guid.Parse("5ff782a8-3d4f-44c8-bbcc-6e01d9967078"),
                     Name = "Malaysia",
                     Code = "MLS",
                     ImageUrl = "https://www.shutterstock.com/search/malaysia-map"
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
