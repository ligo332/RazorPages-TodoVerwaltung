using System;
using System.Collections.ObjectModel;
using RazorPagesTodo.Models;

namespace RazorPagesTodo.Data
{
    /// <summary>
    /// Provides a non-persistent, in-memory implementation of <see cref="ITodoRepository"/>.
    /// Stores todo items in an <see cref="ObservableCollection{T}"/> and initializes the
    /// repository with sample data for development and demonstration purposes.
    /// </summary>
    public sealed class InMemoryTodoRepository : ITodoRepository
    {
        // This repository is intentionally non-persistent to keep the sample simple.
        // Seed data: 5 items, 2 completed.

        public ObservableCollection<TodoItem> Items { get; } =
        [
            new()
            {
                Title = "Projektstruktur anlegen",
                CreatedAt = DateTime.Now.AddDays(-4),
                IsCompleted = true
            },
            new()
            {
                Title = "Mockups fuer die Startansicht erstellen",
                CreatedAt = DateTime.Now.AddDays(-3),
                IsCompleted = false
            },
            new()
            {
                Title = "Datenmodell finalisieren",
                CreatedAt = DateTime.Now.AddDays(-2),
                IsCompleted = false
            },
            new()
            {
                Title = "Erste Tests schreiben",
                CreatedAt = DateTime.Now.AddDays(-1),
                IsCompleted = true
            },
            new()
            {
                Title = "Dokumentation ergaenzen",
                CreatedAt = DateTime.Now,
                IsCompleted = false
            }
        ];

        public ObservableCollection<TodoItem> GetAll()
        {
            return this.Items;
        }


        public TodoItem? GetById(Guid id)
        {
            return this.Items.FirstOrDefault(item => item.Id == id);
        }

        public void Update(TodoItem item)
        {
            TodoItem? existingItem = this.GetById(item.Id);
            if (existingItem is null) {
                return;
            }

            existingItem.Title = item.Title;
            existingItem.Priority = item.Priority;
            existingItem.IsCompleted = item.IsCompleted;

        }

        public void Add(TodoItem item)
        {
            this.Items.Add(item);
        }

        public void Delete(Guid id)
        {
            //TodoItem? item = this.GetById(id);

            TodoItem? item = this.Items.FirstOrDefault(TodoItem => TodoItem.Id == id);

            if (item is not null)
            {
                this.Items.Remove(item);
            }
        }

        public void ToggleCompleted(Guid id)
        {
            TodoItem? item = this.GetById(id);

            if (item is not null)
            {
                item.IsCompleted = !item.IsCompleted;
            }
        }
    }
}
