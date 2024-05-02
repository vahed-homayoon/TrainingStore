using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TrainingStore.Domain.People;
using TrainingStore.Domain.Students;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Infrastructure.Configurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
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
			.IsRequired()
			.HasAnnotation("RegularExpression", @"^\d{10}$");

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

		builder.HasDiscriminator<string>("Type")
		   .HasValue<Person>("Person")
		   .HasValue<Student>("Student")
		   .HasValue<Teacher>("Teacher");
	}
}