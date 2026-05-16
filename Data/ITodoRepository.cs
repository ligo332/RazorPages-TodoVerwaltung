using System.Collections.ObjectModel;
using RazorPagesTodo.Models;

namespace RazorPagesTodo.Data;
/// <summary>
/// Defines a repository for todo items.
/// </summary>
public interface ITodoRepository
{
    ObservableCollection<TodoItem> Items { get; }

    ObservableCollection<TodoItem> GetAll();

    TodoItem? GetById(Guid id);

    void Add(TodoItem item);
    void Delete(Guid id);

    void ToggleCompleted(Guid id);

    void Update(TodoItem item);
}
