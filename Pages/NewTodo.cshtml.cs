using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTodo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RazorPagesTodo.Pages
{
    [BindProperties]
    public class NewTodoModel : PageModel
    {

        public void OnGet()
        {
        }
    }
}
