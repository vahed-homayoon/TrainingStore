using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Infrastructure.Configurations;

internal sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
	public void Configure(EntityTypeBuilder<Teacher> builder)
	{
		builder
			.Property(teacher => teacher.Address)
			.HasMaxLength(100);

		//builder.HasOne<Session>()
		//  .WithMany()
		//  .HasForeignKey(teacher => teacher.Id);
	}
}