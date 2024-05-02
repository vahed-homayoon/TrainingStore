using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.People;
using TrainingStore.Domain.Students;
using TrainingStore.Domain.Teachers;
using TrainingStore.Infrastructure.People.Enums;

namespace TrainingStore.Infrastructure.People.Config;

internal sealed class PersonConfig : IEntityTypeConfiguration<Person>
{
	public void Configure(EntityTypeBuilder<Person> builder)
	{
		builder.ToTable("People");

		builder.HasKey(person => person.Id);

		builder
			.Property(person => person.NationalCode)
			.IsUnicode()
			.HasMaxLength(10)
			.IsFixedLength()
			.IsRequired();

		builder
			.Property(person => person.FirstName)
			.HasMaxLength(50)
			.IsRequired();
		builder
			.Property(person => person.SureName)
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(person => person.Phone)
			.HasMaxLength(15)
			.IsRequired();

		builder
			.Property(person => person.Email)
			.HasMaxLength(50);

		builder.HasDiscriminator<PersonType>("Type")
		   .HasValue<Person>(PersonType.Person)
		   .HasValue<Teacher>(PersonType.Teacher)
		   .HasValue<Student>(PersonType.Student);
	}
}