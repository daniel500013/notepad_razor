using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace notepad_razor.Pages.Subjects
{
    public class DeletePostModel : PageModel
    {
        private readonly NotepadDbContext context;
        public DeletePostModel(NotepadDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var posts = context.Posts.FirstOrDefault(x => x.Id == id);

            if (posts != null)
            {
                context.Posts.Remove(posts);
                await context.SaveChangesAsync();

                return LocalRedirect($"/Subjects/GetPost?subject={posts.Subject}");
            }

            return Page();
        }
    }
}
