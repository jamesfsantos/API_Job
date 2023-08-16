using Jobs.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobs.Core.Data.EntityConfigs;

public class JobEntityCOnfig : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("Jobs");

        builder.HasKey(j => j.Id);
        builder.Property(j => j.Title)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(j => j.Salary)
            .IsRequired()
            .HasPrecision(18, 2);
        builder.Property(j => j.Requirements)
            .IsRequired()
            .HasMaxLength(500);
    }
}