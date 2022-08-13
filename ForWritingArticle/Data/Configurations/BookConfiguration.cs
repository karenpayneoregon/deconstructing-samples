﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using ForWritingArticle.Data;
using ForWritingArticle.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;

namespace ForWritingArticle.Data.Configurations
{
    public partial class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> entity)
        {
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Book> entity);
    }
}