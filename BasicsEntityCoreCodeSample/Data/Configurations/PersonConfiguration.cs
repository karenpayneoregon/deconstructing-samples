﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Switches.Data;
using Switches.Models;
using System;

namespace Switches.Data.Configurations
{
    public partial class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.Property(e => e.Discriminator)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.HireDate).HasColumnType("datetime");

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Person> entity);
    }
}