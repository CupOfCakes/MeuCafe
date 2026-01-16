using Domain.Entities;
using Infrastructure.Persistence.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;

namespace Infrastructure.Persistence.Mappings;

public class ClientMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        //TABLE
        builder.ToTable("clients");
        
        //PK ID
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever();

        //NAME
        builder.Property(c => c.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(c => c.Name)
            .IsUnique()
            .HasDatabaseName(ClientConstraints.UniqueName);

        //EMAIL
        builder.Property(c => c.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(c => c.Email)
            .IsUnique()
            .HasDatabaseName(ClientConstraints.UniqueEmail);

        //HASHPASSWORD
        builder.Property(c => c.HashPassword)
            .HasColumnName("hash_password")
            .IsRequired()
            .HasMaxLength(255);

        //DESCRIPTION
        builder.Property(c => c.Description)
            .HasColumnName("description");
            
        //PROFILE PIC URL
        builder.Property(c => c.ProfilePicURL)
            .HasColumnName("profile_pic_url");

        //BACKGROUND PIC URL
        builder.Property(c => c.BackgroundPicURL)
            .HasColumnName("background_pic_url");

        //CREATE AT
        builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz")
            .IsRequired()
            .HasDefaultValueSql("now()");

        //IS ACTIVE
        builder.Property(c => c.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(true);

    }
}