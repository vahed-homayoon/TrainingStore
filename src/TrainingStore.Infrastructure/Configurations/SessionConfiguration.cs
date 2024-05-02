﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.Sessions;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Infrastructure.Configurations;

internal sealed class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions");

		builder.HasKey(session => session.Id);

		builder
			.Property(session => session.StartDate)
			.IsRequired();

		//builder
		//	.HasOne(s => s.Teacher)
		//	.WithOne()
		//	.HasForeignKey<Session>(session => session.TeacherId);
	}
}