using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTodo.Data;
using RazorPagesTodo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesTodo.Pages
{
    [BindProperties]
    public class EditTodoModel : PageModel
    {
        private readonly ITodoRepository todoRepository;

        public EditTodoModel(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        /// <summary>
        /// Gets or sets the editable todo input.
        /// </summary>
        [BindProperty]
        public EditTodoInputModel Input { get; set; } = new();

        public IActionResult OnGet(Guid id)
        {
            TodoItem? todoItem = this.todoRepository.GetById(id);

            if (todoItem is null)
            {
                return this.NotFound();
            }

            this.Input = new EditTodoInputModel
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Priority = todoItem.Priority,
                IsCompleted = todoItem.IsCompleted
            };

            return this.Page();
        }

        public IActionResult OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            TodoItem updatedItem = new()
            {
                Id = this.Input.Id,
                Title = this.Input.Title,
                Priority = this.Input.Priority,
                IsCompleted = this.Input.IsCompleted
            };

            this.todoRepository.Update(updatedItem);

            return this.RedirectToPage("/Todo");
        }

        public sealed class EditTodoInputModel
        {
            public Guid Id { get; set; }

            [Required(ErrorMessage = "Bitte gib einen Titel ein.")]
            public string Title { get; set; } = string.Empty;

            [Required(ErrorMessage = "Bitte wähle eine Priorität aus.")]
            public string Priority { get; set; } = string.Empty;

            public bool IsCompleted { get; set; }
        }
    }
}
