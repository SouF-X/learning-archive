using EF_Query_Data.Entities;
using EF_Query_Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Query_Data.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)

            builder.Property(x => x.ScheduleType)
                .HasConversion(
                     x => x.ToString(),
                     x => (ScheduleType)Enum.Parse(typeof(ScheduleType), x)
                );

            builder.ToTable("Schedules");
        }
    }
}
