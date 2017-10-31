using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoDAL.Context
{
    class EASVContext : DbContext
    {
        public EASVContext(DbContextOptions<EASVContext> options): base(options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Video> Video { get; set; }
       
    }
}