namespace RazorPagesTodo.Services;

/// <summary>
/// Defines a service for displaying confirmation dialogs.
/// </summary>
public interface IConfirmationService
{
    /// <summary>
    /// Displays a confirmation dialog with the specified message and title.
    /// </summary>
    /// <param name="message">The message displayed in the confirmation dialog.</param>
    /// <param name="title">The title of the confirmation dialog.</param>
    /// <returns><see langword="true"/> if the user confirms the action; otherwise, <see langword="false"/>.</returns>
    bool Confirm(string message, string title);
}
