using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RazorPagesTodo.Models
{
    public class TodoItem //: INotifyPropertyChanged
    {
        private string title = string.Empty;
        private string priority = string.Empty;
        private bool isCompleted;

        /// <summary>
        /// Gets the unique stable identifier of the todo item
        /// to help with selection and potential future persistence.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the title of the todo item.
        /// </summary>
        public string Title
        {
            get => this.title;
            set => this.SetField(ref this.title, value);
        }

        /// <summary>
        /// Gets the date and time when the todo item was created.
        /// Creation date is immutable after the item is created.
        /// </summary>
        public DateTime CreatedAt { get; init; }

        /// <summary>
        /// Gets or sets the priority of the todo item.
        /// </summary>
        public string Priority
        {
            get => this.priority;
            set => this.SetField(ref this.priority, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the todo item is completed.
        /// </summary>
        public bool IsCompleted
        {
            get => this.isCompleted;
            set => this.SetField(ref this.isCompleted, value);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Sets the specified field and raises the <see cref="PropertyChanged"/> event if the value changes.
        /// </summary>
        /// <typeparam name="T">The type of the field value.</typeparam>
        /// <param name="field">The field to update.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">The name of the property that changed.</param>
        
        private void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
            {
                return;
            }

            field = value;
            this.PropertyChanged?.Invoke(this, new(propertyName));
        }
    }
}
