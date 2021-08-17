using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace TaskTracker.Sandbox
{
    public static class TodoPrinter
    {
        public static void Print(this IEnumerable<TodoItem> todoItems)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine();
            foreach (var todoItem in todoItems)
            {
                Console.WriteLine("id: " + todoItem.Id);
                Console.WriteLine("title: " + todoItem.Title);
                Console.WriteLine("nesting level: " + todoItem.NestingLevel);
                Console.WriteLine("todo list id: " + (todoItem.TodoListId ?? -1));
                Console.WriteLine("parent todo item id: " + (todoItem.ParentTodoItemId ?? -1));
                Console.WriteLine();
            }
            Console.WriteLine("=============================================");
        }
        
        public static void PrintNestedTodoItems(this TodoItem rootTodoItem, int indent)
        {
            if (!rootTodoItem.NestedTodoItems.Any())
            {
                return;
            }

            for (int i = 0; i < indent; i++)
            {
                Console.Write(" ");
            }

            foreach (var todo in rootTodoItem.NestedTodoItems)
            {
                Console.WriteLine("Nested todo title: " + todo.Title);
                todo.PrintNestedTodoItems(indent + 4);
            }
        }
    }
}