using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static IncludeAllHeirarchy.Data.AppDbContext;

namespace IncludeAllHeirarchy.Data.Config
{
    public class SectionScheduleConfiguration : IEntityTypeConfiguration<SectionSchedule>
    {
        public void Configure(EntityTypeBuilder<SectionSchedule> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartTime)
                .HasColumnType("time");

            builder.Property(x => x.EndTime)
                .HasColumnType("time");

            builder.ToTable("SectionSchedules");

        }
    }
}
