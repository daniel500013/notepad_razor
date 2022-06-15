using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace notepad_razor.Pages.Auth
{
    public class CompleteRegisterModel : PageModel
    {
        private readonly NotepadDbContext context;
        public CompleteRegisterModel(NotepadDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> OnGet(UserModel UserModel)
        {
            if (ModelState.IsValid)
            {
                var userID = context.Users.FirstOrDefault(x => x.Email == UserModel.Email)?.Id;

                await context.AddAsync(new SubjectModel { Subject = "Polski", UserID = userID });
                await context.AddAsync(new SubjectModel { Subject = "Matematyka", UserID = userID });
                await context.AddAsync(new SubjectModel { Subject = "Angielski", UserID = userID });

                await context.SaveChangesAsync();

                return LocalRedirect("/");
            }
            else
            {
                return LocalRedirect("/Auth/Register");
            }
        }
    }
}
