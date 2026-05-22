using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTodo.Data;
using RazorPagesTodo.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesTodo.Pages
{
    public class TodoModel : PageModel
    {
        private readonly ITodoRepository todoRepository;

        public TodoModel(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public IReadOnlyCollection<TodoItem> TodoItems { get; private set; } = [];

        /// <summary>
        /// Gets or sets the todo input submitted by the form.
        /// </summary>
        [BindProperty]
        public TodoInputModel Input { get; set; } = new();

        public IActionResult OnPostAdd()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            TodoItem item = new()
            {
                Title = this.Input.Title,
                Priority = this.Input.Priority,
                CreatedAt = DateTime.Now,
                IsCompleted = this.Input.IsCompleted
            };

            this.todoRepository.Add(item);

            return this.RedirectToPage();
        }

        public IActionResult OnPostDelete(Guid id)
        {
            this.todoRepository.Delete(id);

            return this.RedirectToPage();
        }

        public IActionResult OnPostToggleCompleted(Guid id)
        {
            this.todoRepository.ToggleCompleted(id);

            return this.RedirectToPage();
        }

        public sealed class TodoInputModel
        {
            [Required(ErrorMessage = "Bitte gib einen Titel ein.")]
            public string Title { get; set; } = string.Empty;
            [Required(ErrorMessage = "Bitte gib eine Priorität an.")]
            public string Priority { get; set; } = string.Empty;

            public bool IsCompleted { get; set; }
        }

        public IActionResult OnPostEditSelected(Guid[] selectedTodoIds)
        {
            if (selectedTodoIds.Length == 0)
            {
                this.ModelState.AddModelError(string.Empty, "Bitte wähle ein Todo aus.");
                this.LoadTodoItems();
                return this.Page();
            }
            return this.RedirectToPage("EditTodo", new { id = selectedTodoIds[0] });
        }

        public IActionResult OnPostDeleteSelected(Guid[] selectedTodoIds)
        {
            if (selectedTodoIds.Length == 0)
            {
                this.ModelState.AddModelError(string.Empty, "Bitte wähle mindestens ein Todo zum Löschen aus.");
                this.LoadTodoItems();
                return this.Page();
            }

            foreach (Guid selectedTodoId in selectedTodoIds)
            {
                this.todoRepository.Delete(selectedTodoId);
            }

            return this.RedirectToPage();
        }

        public void OnGet()
        {
            this.LoadTodoItems();
        }

        private void LoadTodoItems()
        {
            this.TodoItems = this.todoRepository.GetAll();
        }
    }
}