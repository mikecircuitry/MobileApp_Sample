using Microsoft.EntityFrameworkCore;
using ProjectData.Models;
using SkDemo.Models;

namespace Repository
{
    public class ProjectDataContext : DbContext
    {
        public ProjectDataContext(DbContextOptions<ProjectDataContext> options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        
    }
}