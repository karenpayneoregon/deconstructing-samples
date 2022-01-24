﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Switches.Data;
using Switches.Models;
using System;

namespace Switches.Data.Configurations
{
    public partial class OnsiteCourseConfiguration : IEntityTypeConfiguration<OnsiteCourse>
    {
        public void Configure(EntityTypeBuilder<OnsiteCourse> entity)
        {
            entity.HasKey(e => e.CourseID);

            entity.Property(e => e.CourseID).ValueGeneratedNever();

            entity.Property(e => e.Days)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Time).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Course)
                .WithOne(p => p.OnsiteCourse)
                .HasForeignKey<OnsiteCourse>(d => d.CourseID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OnsiteCourse_Course");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<OnsiteCourse> entity);
    }
}