using Autofac;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TaskTrackerDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<TodoItemRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<TodoListRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}