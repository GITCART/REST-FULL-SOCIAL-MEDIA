using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
                  .HasColumnName("IdUsuario");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("Apellidos")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.DateBirth)
                .HasColumnName("FechaNacimiento")
                .HasColumnType("date");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("Nombres")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Telephone)
                .HasColumnName("Telefono")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.ISActive)
                  .HasColumnName("Activo");
        }
    }
}
