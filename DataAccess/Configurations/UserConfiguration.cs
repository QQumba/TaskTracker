using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // builder.HasAlternateKey(x => x.Email);
            builder.HasIndex(x => x.Email).IsUnique();
            
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Salt).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            
            builder.ToTable("task_tracker_user");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Salt).HasColumnName("salt");
            builder.Property(x => x.Password).HasColumnName("password");
            builder.Property(x => x.CreatedTimestamp).HasColumnName("created_timestamp");
            builder.Property(x => x.UpdatedTimestamp).HasColumnName("updated_timestamp");
        }
    }
}