using Jobs.Core.Data.EntityConfigs;
using Jobs.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Core.Data.Contexts;

public class JobsDbContext : DbContext
{
    public DbSet<Job> Jobs => Set<Job>();

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=Localhost\\SQLEXPRESS;Database=Jobs;Trusted_Connection=True;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new JobEntityCOnfig());
    }
}