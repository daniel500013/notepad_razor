using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace notepad_razor.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        public NotepadDbContext context;

        public IndexModel(NotepadDbContext _context)
        {
            context = _context;
        }

        public IList<SubjectModel> schoolSubjects;

        public void OnGet()
        {
            int id = int.Parse(User.FindFirst("ID").Value);
            schoolSubjects = context.Subjects.Where(x => x.UserID.Equals(id)).ToList();
        }
    }
}
