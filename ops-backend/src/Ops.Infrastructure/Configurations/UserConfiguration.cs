using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ops.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasMaxLength(500);  // To store the Hashed Pwd

            builder.Property(x => x.Role);
            //0 or 1 or 2 - check constraint//Already covered through enum

            builder.Property(x => x.MobileNumber)
                    .HasMaxLength(15);

            builder.Property(x => x.Email)
                    .HasMaxLength(100)
                    .IsRequired();

            // Unique Username
            builder.HasIndex(x => x.UserName)
                   .IsUnique()
                   .HasDatabaseName("IX_Users_UserName");

            builder.HasIndex(x => x.MobileNumber)
                   .IsUnique()
                   .HasDatabaseName("IX_Users_MobileNumber");

            builder.HasIndex(x => x.Email)
                   .IsUnique()
                   .HasDatabaseName("IX_Users_Email");
        }
    }
}