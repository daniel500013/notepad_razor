using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace notepad_razor.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        private readonly NotepadDbContext context;

        public LogoutModel(NotepadDbContext _context)
        {
            context = _context;
        }

        public IActionResult OnGet()
        {
            HttpContext.SignOutAsync();
            return LocalRedirect("/");
        }
    }
}
