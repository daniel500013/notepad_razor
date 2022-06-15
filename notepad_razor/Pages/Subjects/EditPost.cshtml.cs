using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace notepad_razor.Pages.Subjects
{
    public class EditPostModel : PageModel
    {
        private readonly NotepadDbContext context;

        public EditPostModel(NotepadDbContext _context)
        {
            context = _context;
        }

        public void OnGet(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);

            if (post != null)
            {
                Post = context.Posts.FirstOrDefault(x => x.Id == id);
            }
        }

        [BindProperty]
        public PostModel Post { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);

            if (post != null)
            {
                post.Title = Post.Title;
                post.Description = Post.Description;
                context.Update(post);

                await context.SaveChangesAsync();

                return LocalRedirect($"/Subjects/GetPost?subject={post.Subject}");
            }
            else
            {
                return Page();
            }
        }
    }
}
