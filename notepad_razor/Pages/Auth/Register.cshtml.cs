using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace notepad_razor.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly NotepadDbContext context;
        private readonly IPasswordHasher<UserModel> passwordhasher;

        public RegisterModel(NotepadDbContext _context, IPasswordHasher<UserModel> _passwordhasher)
        {
            context = _context;
            passwordhasher = _passwordhasher;
        }

        public void OnGet()
        {
            
        }

        [BindProperty]
        public UserModel UserModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (UserModel == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }

                var claims = new List<Claim>
                {
                    new Claim("ID", UserModel.Id.ToString()),
                    new Claim(ClaimTypes.Name, UserModel.NickName),
                    new Claim(ClaimTypes.Email, UserModel.Email),
                    new Claim(ClaimTypes.Role, UserModel.Permission),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                UserModel.HashedPassword = passwordhasher.HashPassword(UserModel, UserModel.Password);

                context.Add(UserModel);

                context.Add(new SubjectModel { Subject = "Polski", UserID = UserModel.Id });
                context.Add(new SubjectModel { Subject = "Matematyka", UserID = UserModel.Id });
                context.Add(new SubjectModel { Subject = "Angielski", UserID = UserModel.Id });

                await context.SaveChangesAsync();

                return LocalRedirect("/");
            }
            else
            {
                return Page();
            }
        }
    }
}
