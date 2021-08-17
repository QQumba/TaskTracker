using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NestingLevel).IsRequired();
            builder.Property(x => x.Title).IsRequired();

            builder
                .HasOne(x => x.ParentTodoItem)
                .WithMany(x => x.NestedTodoItems)
                .HasForeignKey(x => x.ParentTodoItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.TodoList)
                .WithMany(x => x.TodoItems)
                .HasForeignKey(x => x.TodoListId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.TodoItems)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("todo_item");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x => x.Note).HasColumnName("note");
            builder.Property(x => x.Done).HasColumnName("done");
            builder.Property(x => x.NestingLevel).HasColumnName("nesting_level");
            builder.Property(x => x.TodoListId).HasColumnName("todo_list_id");
            builder.Property(x => x.ParentTodoItemId).HasColumnName("parent_todo_item_id");
            builder.Property(x => x.Deadline).HasColumnName("deadline");
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.ExactTimeDeadline).HasColumnName("exact_time_deadline");
            builder.Property(x => x.ParentTodoItemId).HasColumnName("parent_todo_item_id");
            
            builder.Property(x => x.CreatedTimestamp).HasColumnName("created_timestamp");
            builder.Property(x => x.UpdatedTimestamp).HasColumnName("updated_timestamp");
        }
    }
}