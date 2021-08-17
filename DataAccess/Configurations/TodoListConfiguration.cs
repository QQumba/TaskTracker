using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.TodoLists)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("todo_list");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.CreatedTimestamp).HasColumnName("created_timestamp");
            builder.Property(x => x.UpdatedTimestamp).HasColumnName("updated_timestamp");
        }
    }
}