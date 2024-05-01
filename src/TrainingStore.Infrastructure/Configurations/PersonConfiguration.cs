using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.People;
using TrainingStore.Domain.Students;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Infrastructure.Configurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
	public void Configure(EntityTypeBuilder<Person> builder)
	{
		builder.ToTable("People");

		builder.HasKey(m => m.Id);

		builder
			.Property(b => b.NationalCode)
			.HasMaxLength(10)
			.IsRequired();

		builder
			.Property(b => b.FirstName)
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(b => b.SureName)
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(b => b.Phone)
			.HasMaxLength(15)
			.IsRequired();

		builder
			.Property(b => b.Email)
			.HasMaxLength(50)
			.IsRequired();

		builder.HasDiscriminator<string>("Type")
		   .HasValue<Person>("Person")
		   .HasValue<Student>("Student")
		   .HasValue<Teacher>("Teacher");
	}
}