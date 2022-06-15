using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace notepad_razor.Pages.Subjects
{
    public class CreatePostModel : PageModel
    {
        private readonly NotepadDbContext context;

        public CreatePostModel(NotepadDbContext _context)
        {
            context = _context;
        }

        public void OnGet(string subject)
        {
            
        }

        [BindProperty]
        public PostModel Post { get; set; }

        public async Task<IActionResult> OnPostAsync(string subject)
        {
            Post.Subject = subject;
            ModelState.ClearValidationState(nameof(Post));
            if (TryValidateModel(Post, nameof(Post)))
            {
                
                await context.AddAsync(Post);
                await context.SaveChangesAsync();

                return LocalRedirect($"/Subjects/GetPost?subject={Post.Subject}");
            }
            else
            {
                return Page();
            }
        }
    }
}
