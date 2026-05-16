using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace RazorPagesTodo.Services;


/// <summary>
/// Provides confirmation dialogs for user decisions.
/// </summary>
public sealed class ConfirmationService //: IConfirmationService
{
    /*
    
    /// <summary>
    /// Displays a confirmation dialog with a specified message and title.
    /// </summary>
    /// <param name="message">The message displayed in the confirmation dialog.</param>
    /// <param name="title">The title of the confirmation dialog.</param>
    /// <returns><see langword="true"/> if the user confirms the action; otherwise, <see langword="false"/>.</returns>
    public bool Confirm(string message, string title)
    {
        MessageBoxResult result = MessageBox.Show(
            owner: Application.Current.MainWindow ?? throw new InvalidOperationException(),
            messageBoxText: message,
            caption: title,
            button: MessageBoxButton.YesNo,
            icon: MessageBoxImage.Warning);

        return result == MessageBoxResult.Yes;
    }

    */
}

