using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace notepad_razor.Pages.Subjects
{
    public class GetPostModel : PageModel
    {
        private readonly NotepadDbContext context;

        public GetPostModel(NotepadDbContext _context)
        {
            context = _context;
        }

        [BindProperty]
        public IList<PostModel> posts { get; set; }

        public string Subject; 

        public async Task OnGet(string subject)
        {
            Subject = subject;

            posts = await context.Posts
                .Where(p => p.Subject.Equals(subject))
                .Where(x => x.UserClass == int.Parse(User.FindFirst("Class").Value))
                .ToListAsync();
        }
    }
}
