using System.Runtime.CompilerServices;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mappings;

public class UserMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        //TABLE
        builder.ToTable("clients");
        
        //PK ID
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("id")
            .IsRequired();
        
        //NAME
        builder.Property(u => u.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(50);
        
        //EMAIL
        builder.Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(255);

        
        
        //HASHPASSWORD
        builder.Property(u => u.HashPassword)
            .HasColumnName("hash_password")
            .IsRequired()
            .HasMaxLength(255);
        
        //DESCRIPTION
        builder.Property(u => u.Description)
            .HasColumnName("description");
            
        //PROFILE PIC URL
        builder.Property(u => u.ProfilePicURL)
            .HasColumnName("profile_pic_url");

        //BACKGROUND PIC URL
        builder.Property(u => u.BackgroundPicURL)
            .HasColumnName("background_pic_url");

        //CREATE AT
        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

    }
}